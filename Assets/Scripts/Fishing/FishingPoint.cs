using UnityEngine;
using System.Collections.Generic;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Место, в котором можно ловить рыбу. На данный момент визуально отображается в виде зацикленной анимации пузырьков.
    /// </summary>
    public class FishingPoint : MonoBehaviour
    {
        private static HashSet<FishingPoint> _allFishingPoints;
        public static IReadOnlyCollection<FishingPoint> AllFishingPoints => _allFishingPoints;

        public static event Action OnFishPointDestroy;

        [SerializeField] private Fish _fishPrefab;
        [SerializeField] private FishPool _fishPoolPrefab;
        [SerializeField] private GameObject _bubbles;
        [SerializeField] private SpriteRenderer _circleOfFish;
        [SerializeField] private Sprite[] _cirleSprites;
        [SerializeField] private Rotator _rotation;

        FishingChallenge FishingChallenge => FishingChallenge.Instance;
        
        private Fish _fish;
        private bool _isActive = false; 

        #region UnityEvents      
        private void Start()
        {
            _bubbles.gameObject.SetActive(false);        
            _circleOfFish.enabled = true;
            _rotation.enabled = true;

            if (_cirleSprites.Length > 0)
            {
                int index = UnityEngine.Random.Range(0, _cirleSprites.Length);
                _circleOfFish.sprite = _cirleSprites[index];    
            }

            if (_allFishingPoints == null)
            {
                _allFishingPoints = new HashSet<FishingPoint>();
            }

            _allFishingPoints.Add(this);          
            
            FishingChallenge.OnEnable += SetBubblesAnimationActive;
            FishingChallenge.OnTryCatchFish += ShowCatchedFish;
        }

        private void OnDestroy()
        {
            FishingChallenge.OnEnable -= SetBubblesAnimationActive;
            FishingChallenge.OnTryCatchFish -= ShowCatchedFish;       
        }
        #endregion

        private void ShowCatchedFish(bool success)
        {
            if (_isActive)
            {
                if (success)
                {
                    _fish = Instantiate(_fishPrefab, transform.position, Quaternion.identity);
                    _fish.Sprite.enabled = false; // Attention!
                    
                    _fishPoolPrefab.Initialize();

                    if (DropProbability.Value <= _fishPoolPrefab.ArtifactChance)
                    {
                        var artifacts = _fishPoolPrefab.ArtifactArray;
                        if (artifacts.Length > 0)
                        {
                            int index = UnityEngine.Random.Range(0, artifacts.Length);
                            _fish.Initialize(artifacts[index]);
                        }
                    }
                    else
                    {
                        var fishes = _fishPoolPrefab.CurrentArray;
                        if (fishes.Length > 0)
                        {
                            int index = UnityEngine.Random.Range(0, fishes.Length);
                            _fish.Initialize(fishes[index]);
                        }
                    }

                    Player.Instance.FishingRod.AssignFish(_fish);
                }
                else
                {
                    Player.Instance.FishingRod.AssignFish(null);
                }

                FishingChallenge.OnDisable += DestroyItself;
            }          
        }

        private void DestroyItself()
        {
           FishingChallenge.OnDisable -= DestroyItself;

            if (_fish != null)
            {
                Destroy(_fish.gameObject);
            }

            _allFishingPoints.Remove(this);

            OnFishPointDestroy?.Invoke();

            Destroy(gameObject);          
        }

        private void SetBubblesAnimationActive()
        {
            if (_isActive)
            {
                _bubbles.gameObject.SetActive(true);
                _circleOfFish.enabled = false;
                _rotation.enabled = false;
            }
        }

        public void SetActive(bool value)
        {
            _isActive = value;
        }
    }
}