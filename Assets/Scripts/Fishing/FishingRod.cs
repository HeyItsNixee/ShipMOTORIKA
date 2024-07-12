using System;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShipMotorika
{
    public class FishingRod : MonoBehaviour, ILoader, ISaver//, IInitializer
    {
        [SerializeField] private FishingRodAsset _asset;
        public FishingRodAsset Asset => _asset;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private string _description;
        public string Description => _description;

        [SerializeField] private CircleCollider2D _fishingRodCircleCollider;

        [SerializeField] private CapsuleCollider2D _shipCapsuleCollider;

        [SerializeField] private float _radius;
        public float Radius => _radius;

        [SerializeField] private float _speed;
        public float Speed => _speed;

        [SerializeField] private int _cost;
        public int Cost => _cost;

        private FishingPoint _activeFishingPoint;
        public FishingPoint FishingPoint => _activeFishingPoint;

        private Fish _сaughtFish;
        public Fish CaughtFish => _сaughtFish;

        private List<FishingPoint> _fishingPoints;
        private Collider2D _fishingPointCollider;

        private bool _isTriggered = false;

        public event Action<bool> OnFishingPlaceNearby;
        public event Action OnFishAssigned;
        public event Action OnFishingRodInitialized;

        #region UnityEvents
        private void Awake()
        {
            SceneDataHandler.Loaders.Add(this);
            SceneDataHandler.Savers.Add(this);
        }

        private void Start()
        {
            if (!SceneDataHandler.Instance.HasSave())
            {
                Initialize(_asset);
            }

            _fishingPoints = new List<FishingPoint>();
        }

        /// <summary>
        /// Показываем кнопку, по нажатию которой запустится мини-игра ловли рыбы.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<FishingPoint>(out var fishingPoint))
            {
                _fishingPointCollider = collision;

                if (!_isTriggered) // Защита от срабатывания нескольких FishingPoint при попадании в триггер.
                {
                    _isTriggered = true;
                    _activeFishingPoint = fishingPoint;
                    _activeFishingPoint.SetActive(true);

                    OnFishingPlaceNearby?.Invoke(true);
                }
            }
        }

        /// <summary>
        /// Перестаем показывать кнопку, по нажатию которой запустится мини-игра ловли рыбы.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _fishingPointCollider)
            {
                if (_isTriggered)
                {
                    _isTriggered = false;
                    _activeFishingPoint.SetActive(false);
                    _activeFishingPoint = null;

                    OnFishingPlaceNearby?.Invoke(false);
                }
            }
        }

#if UNITY_EDITOR      
        /// <summary>
        /// Для удобства Помогает отобразить радиус действия удочки на сцене.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif
        #endregion

        private void SetDefaultRadius()
        {
            float x = _shipCapsuleCollider.size.x;
            float y = _shipCapsuleCollider.size.y;

            _radius = Mathf.Max(x, y);
        }

        public void Initialize(FishingRodAsset asset)
        {
            SetDefaultRadius();

            _asset = asset;
            _spriteRenderer.sprite = asset.GameSprite;
            _name = asset.Name;
            _description = asset.Description;
            _speed = asset.Speed;
            _radius = _radius + asset.Radius;
            _cost = asset.Cost;

            _fishingRodCircleCollider.radius = _radius;

            OnFishingRodInitialized?.Invoke();
        }

        /// <summary>
        /// Дополнительная проверка на рыбу вокруг. На случай, если в радиусе действия было несколько точек рыбы, и сработала защита OnTriggerEnter.
        /// </summary>
        public void FindFishNearby()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);

            if (hits.Length > 0)
            {
                _fishingPoints.Clear();

                foreach (var hit in hits)
                {
                    if (hit.gameObject.TryGetComponent<FishingPoint>(out var point))
                    {
                        _fishingPoints.Add(point);
                    }
                }

                FishingPoint closestFishingPoint = null;
                float minDistance = Mathf.Infinity;

                foreach (var fishingPoint in _fishingPoints)
                {
                    float distance = Vector2.Distance(transform.position, fishingPoint.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestFishingPoint = fishingPoint;
                    }
                }

                if (closestFishingPoint != null)
                {
                    if (!_isTriggered)
                    {
                        _isTriggered = true;
                        _activeFishingPoint = closestFishingPoint;
                        _activeFishingPoint.SetActive(true);

                        OnFishingPlaceNearby?.Invoke(true);
                    }
                }
            }
        }

        public void AssignFish(Fish fish)
        {
            _сaughtFish = fish;

            OnFishAssigned?.Invoke();
        }

        public void TryPutFishInShip()
        {
            if (_сaughtFish != null)
            {
                var container = Player.Instance.Ship.FishContainer;

                container.ChangeWeightAmount(_сaughtFish.Weight);
                container.ChangeCostAmount(_сaughtFish.Cost);
            }
        }

        public void Load()
        {
            var data = SceneDataHandler.Data;
            var asset = Resources.Load<FishingRodAsset>(data.FishingRodAssetName);

            if (asset != null)
            {
                Initialize(asset);
            }
        }

        public void Save()
        {
            var data = SceneDataHandler.Data;
            var fishingRod = Player.Instance.FishingRod;

            data.FishingRodAssetName = fishingRod.Asset.name;
        }
    }
}