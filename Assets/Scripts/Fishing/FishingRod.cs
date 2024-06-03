using System;
using UnityEngine;
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
        [SerializeField] private FishingRodAsset _asset;

        /// <summary>
        /// Название удочки (для магазина).
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;
        
        /// <summary>
        /// В зависимости от радиуса этого коллайдера зависит расстояние от FishingPlace, на котором можно ловить рыбу.
        /// </summary>
        [SerializeField] private CircleCollider2D _circleCollider;

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

        private FishingPoint _fishingPoint;
        public FishingPoint FishingPoint => _fishingPoint;

        public event Action<bool> OnFishingPlaceNearby;

        private Fish _lastCaughtFish = null;
        public Fish LastCaughtFish => _lastCaughtFish;

        #region UnityEvents
        private void Start()
        {
            Initialize(_asset);
        }

        /// <summary>
        /// Показываем кнопку, по нажатию которой запустится мини-игра ловли рыбы.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<FishingPoint>(out var fishingPoint))
            {
                _fishingPoint = fishingPoint;
                _fishingPoint.SetActive(true);
                OnFishingPlaceNearby(true);
            }
        }

        /// <summary>
        /// Перестаем показывать кнопку, по нажатию которой запустится мини-игра ловли рыбы.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<FishingPoint>(out var fishingPlace))
            {
                _fishingPoint.SetActive(false);
                _fishingPoint = null;
                OnFishingPlaceNearby(false);
            }
        }

        /// <summary>
        /// Для удобства Помогает отобразить радиус действия удочки на сцене.
        /// </summary>

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif
#endregion

        /// <summary>
        /// В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishingRodAsset asset)
        {
            _name = asset.Name; 
            _speed = asset.Speed;
            _radius = asset.Radius;
            _cost = asset.Cost;

            _circleCollider.radius = _radius;
        }

        /// <summary>
        /// Сохраняет информацию о последней пойманной рыбе.
        /// </summary>
        /// <param name="fish"></param>
        public void AssignFish(Fish fish)
        {
            _lastCaughtFish = fish;
        }

        /// <summary>
        /// Добавляет вес пойманной рыбы к текущему весу корабля.
        /// </summary>
        public void TryPutFishInShip()
        {
            if (_lastCaughtFish != null)
            {
                Player.Instance.Ship.TryChangeWeightAmount(_lastCaughtFish.Weight);
            }
        }
    }
}