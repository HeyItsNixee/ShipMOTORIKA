using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Модель корабля игрока.
    /// </summary>
    public class Ship : MonoBehaviour, ILoader, ISaver//, IInitializer
    {
        [SerializeField] private Rigidbody2D rb2d;
        public Rigidbody2D Rigidbody => rb2d;

        /// <summary>
        /// ScriptableObject c параметрами корабля.
        /// </summary>
        [SerializeField] private ShipAsset _asset;
        public ShipAsset Asset => _asset;

        /// <summary>
        /// Визуальное отображение корабля. В данном случае для удобства не стоит выделять визуальное воплощение и модель в отдельные классы.
        /// </summary>
        [SerializeField] private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Коллайдер столкновений спрайта корабля.
        /// </summary>
        [SerializeField] private CapsuleCollider2D _capsuleCollider;

        /// <summary>
        /// Название корабля для интерфейса.
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;

        /// <summary>
        /// Художественное описание корабля. 
        /// </summary>
        [SerializeField] private string _description;
        public string Description => _description;

        /// <summary>
        /// Стоимость корабля у торговца.
        /// </summary>
        [SerializeField] private int _cost;
        public int Cost => _cost;

        /// <summary>
        /// Грузоподъемность корабля. Не может быть меньше суммарного веса собранной рыбы.
        /// </summary>
        [SerializeField] private int _carryingCapacity;
        public int CarryingCapacity => _carryingCapacity;

        /// <summary>
        /// Текущий вес корабля. Сериализованное поле нужно для удобства разработки.
        /// </summary>
        [SerializeField] private int _currentWeight;
        public int CurrentWeight => _currentWeight;

        /// <summary>
        /// Скорость корабля (MaxLinearVelocity).
        /// </summary>
        [SerializeField] private float _speed;
        public float Speed => _speed;

        /// <summary>
        /// Показатель здоровья корабля.
        /// </summary>
        [SerializeField] private Health _health;
        public Health Health => _health;

        /// <summary>
        /// Отсек для хранения рыбы.
        /// </summary>
        [SerializeField] private FishContainer _fishContainer;
        public FishContainer FishContainer => _fishContainer;

        public event Action<bool> OnMarketNearby;
        public event Action<bool> OnBoatShopNearby;
        public event Action<bool> OnFishingRodShopNearby;
        public event Action<bool> OnWorkshopNearby;

        public event Action OnShipInitialized;
        public event Action OnWeightChanged;

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

            _fishContainer.OnFishCaught += TryChangeWeightAmount;
        }

        private void OnDestroy()
        {
            _fishContainer.OnFishCaught -= TryChangeWeightAmount;
        }
        #endregion

        /// <summary>
        ///  В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(ShipAsset asset)
        {
            _asset = asset;
            _spriteRenderer.sprite = asset.GameSprite;
            _capsuleCollider.size = new Vector2(_asset.ColliderX, _asset.ColliderY);
            _name = asset.Name;
            _description = asset.Description;
            _cost = asset.Cost;
            _carryingCapacity = asset.СarryingCapacity;
            _speed = asset.Speed;

            if (_fishContainer)
            {
                _currentWeight = Mathf.Clamp(_fishContainer.Weight, 0, _carryingCapacity);
            }

            _health.SetMaxHealth(asset.Health);

            Player.Instance.PlayerController.SetMaxLinearVelocity(_speed);

            OnShipInitialized?.Invoke();
        }

        /// <summary>
        /// Сообщает о том, что корабль вблизи рынка.
        /// </summary>
        /// <param name="value"></param>
        public void SendMarketMessage(bool value)
        {
            OnMarketNearby?.Invoke(value);
        }

        /// <summary>
        /// Сообщает о том, что корабль вблизи магазина лодок.
        /// </summary>
        /// <param name="value"></param>
        public void SendBoatShopMessage(bool value)
        {
            OnBoatShopNearby?.Invoke(value);
        }

        /// <summary>
        /// Сообщает о том, что корабль вблизи магазина удочек.
        /// </summary>
        /// <param name="value"></param>
        public void SendFishingRodShopMessage(bool value)
        {
            OnFishingRodShopNearby?.Invoke(value);
        }

        /// <summary>
        /// Сообщает о том, что корабль вблизи мастерской.
        /// </summary>
        /// <param name="value"></param>
        public void SendWorkshopMessage(bool value)
        {
            OnWorkshopNearby?.Invoke(value);
        }

        public void TryChangeWeightAmount(int amount)
        {
            if (amount != 0)
            {
                int currentWeight = _currentWeight + amount;

                if (currentWeight >= 0 || currentWeight <= _carryingCapacity)
                {
                    _currentWeight = currentWeight;

                    OnWeightChanged?.Invoke();
                }
            }
        }

        public void Load()
        {
            var data = SceneDataHandler.Data;
            var shipTransform = Player.Instance.Ship.gameObject.transform;
            var asset = Resources.Load<ShipAsset>(data.ShipAssetName);

            shipTransform.position = data.ShipPosition;
            shipTransform.rotation = data.ShipRotation;
            shipTransform.localScale = data.ShipScale;

            if (asset != null)
            {
                Initialize(asset);
            }
        }

        public void Save()
        {
            var data = SceneDataHandler.Data;
            var ship = Player.Instance.Ship;
            var shipTransform = ship.gameObject.transform;

            data.ShipPosition = shipTransform.position;
            data.ShipRotation = shipTransform.rotation;
            data.ShipScale = shipTransform.localScale;
            data.ShipAssetName = ship.Asset.name;
        }
    }
}