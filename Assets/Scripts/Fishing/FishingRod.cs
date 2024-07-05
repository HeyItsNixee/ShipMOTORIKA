using System;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShipMotorika
{
    /// <summary>
    /// Удочка игрока.
    /// </summary>
    public class FishingRod : MonoBehaviour
    {
        /// <summary>
        /// ScriptableObject c параметрами удочки.
        /// </summary>
        [SerializeField] private FishingRodAsset _asset;
        public FishingRodAsset Asset => _asset;

        /// <summary>
        /// Визуальное отображение удочки при ловле рыбы.
        /// </summary>
        [SerializeField] private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Название удочки (для магазина).
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;

        /// <summary>
        /// Описание удочки для торговца.
        /// </summary>
        [SerializeField] private string _description;
        public string Description => _description;
        
        /// <summary>
        /// В соответствии с радиусом этого коллайдера меняет расстояние от FishingPlace, на котором можно ловить рыбу.
        /// </summary>
        [SerializeField] private CircleCollider2D _fishingRodCircleCollider;

        /// <summary>
        /// В зависимости от размеров данного коллайдера будет рассчитываться дефолтный радиус удочки.
        /// </summary>
        [SerializeField] private CapsuleCollider2D _shipCapsuleCollider;

        /// <summary>
        /// Для удобства радиус можно задавать/смотреть через инспектор.
        /// </summary>
        [SerializeField] private float _radius;
        public float Radius => _radius;

        /// <summary>
        /// Скорость ловли удочки. Чем выше, тем легче будет проходить мини-игру FishingChallenge.
        /// </summary>
        [SerializeField] private float _speed;
        public float Speed => _speed;

        /// <summary>
        /// Стоимость удочки у торговца.
        /// </summary>
        [SerializeField] private int _cost;
        public int Cost => _cost;

        /// <summary>
        /// Та FishingPoint, в которой игрок ловит рыбу в данный момент.
        /// </summary>
        private FishingPoint _activeFishingPoint;
        public FishingPoint FishingPoint => _activeFishingPoint;

        /// <summary>
        /// Пойманная рыба.
        /// </summary>
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
            FishingRodData.Load();
        }

        private void Start()
        {
            if (FishingRodData.HasSave())
            {
                Initialize(FishingRodData.Asset);
            }
            else
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

        /// <summary>
        /// Устанавливает радиус в зависимости от коллайдера корабля.
        /// </summary>
        private void SetDefaultRadius()
        {
            float x = _shipCapsuleCollider.size.x;
            float y = _shipCapsuleCollider.size.y;

            _radius = Mathf.Max(x, y);
        }  
        
        /// <summary>
        /// В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
        /// </summary>
        /// <param name="asset"></param>
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

            FishingRodData.Save();
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

        /// <summary>
        /// Сохраняет информацию о последней пойманной рыбе.
        /// </summary>
        /// <param name="fish"></param>
        public void AssignFish(Fish fish)
        {
            _сaughtFish = fish;

            OnFishAssigned?.Invoke();
        }

        /// <summary>
        /// Добавляет вес пойманной рыбы к текущему весу корабля.
        /// </summary>
        public void TryPutFishInShip()
        {
            if (_сaughtFish != null)
            {
                Player.Instance.Ship.FishContainer.ChangeWeightAmount(_сaughtFish.Weight);
                Player.Instance.Ship.FishContainer.ChangeCostAmount(_сaughtFish.Cost);
            }
        }
    }
}