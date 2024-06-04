using UnityEngine;
using System.Collections.Generic;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// �����, � ������� ����� ������ ����. � ������ ������ ��������� ������������ � ���� ����������� �������� ���������.
    /// </summary>
    public class FishingPoint : MonoBehaviour
    {
        /// <summary>
        /// ���� ���� ����������� ������, � ������� ��� �������� ����������� ������ ����� FishingPoint. 
        /// </summary>
        private static HashSet<FishingPoint> _allFishingPoints;
        public static IReadOnlyCollection<FishingPoint> AllFishingPoints => _allFishingPoints;

        public static event Action OnFishPointDestroy;

        /// <summary>
        /// � ���� ������ ���������� ��� "��������" ����/
        /// </summary>
        [SerializeField] private FishAsset[] _fishAssets;  
        
        /// <summary>
        /// �������� �������� ����-��������, �������� "�����" (���������� ��� ��������). ����� ��������� �� ������� ���������� ������ ������.
        /// </summary>
        [SerializeField] private FishAsset _bootAsset;

        [SerializeField] private Fish _fishPrefab;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Fish _fish;

        private bool _isActive = false; 

        #region UnityEvents
        private void Start()
        {
            _spriteRenderer.enabled = true;

            if (_allFishingPoints == null)
            {
                _allFishingPoints = new HashSet<FishingPoint>();
            }

            _allFishingPoints.Add(this);
            
            FishingChallenge.Instance.OnTryCatchFish += ShowCatchedFish;
        }

        private void OnDestroy()
        {        
            _allFishingPoints.Remove(this);

            OnFishPointDestroy?.Invoke();
            
            FishingChallenge.Instance.OnTryCatchFish -= ShowCatchedFish;
        }
        #endregion

        /// <summary>
        /// �������� �������� ��������� ��������� � ���� �������� ���� ��� "������".
        /// </summary>
        /// <param name="success"></param>
        private void ShowCatchedFish(bool success)
        {
            if (_isActive)
            {
                if (success)
                {
                    _fish = Instantiate(_fishPrefab, transform.position, Quaternion.identity);
                    _fish.Sprite.enabled = false; // Attention!

                    // ���� ������� ����� - 10%.
                    int random = UnityEngine.Random.Range(0, 10);
                    if (random == 0)
                    {
                        _fish.Initialize(_bootAsset);
                    }
                    else
                    {
                        int index = UnityEngine.Random.Range(0, _fishAssets.Length);
                        _fish.Initialize(_fishAssets[index]);
                    }

                    Player.Instance.FishingRod.AssignFish(_fish);
                }
                else
                {
                    Player.Instance.FishingRod.AssignFish(null);
                }

                FishingChallenge.Instance.OnDisable += DestroyItself;
            }          
        }

        private void DestroyItself()
        {
            FishingChallenge.Instance.OnDisable -= DestroyItself;

            if (_fish != null)
            {
                Destroy(_fish.gameObject);
            }

            Destroy(gameObject);          
        }

        public void SetActive(bool value)
        {
            _isActive = value;
        }
    }
}