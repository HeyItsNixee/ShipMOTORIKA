using UnityEngine;
using System;

namespace ShipMotorika
{
    public class Ship : MonoBehaviour, ILoader, ISaver//, IInitializer
    {
        [SerializeField] private Rigidbody2D rb2d;
        public Rigidbody2D Rigidbody => rb2d;

        [SerializeField] private ShipAsset _asset;
        public ShipAsset Asset => _asset;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private CapsuleCollider2D _capsuleCollider;

        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private string _description;
        public string Description => _description;

        [SerializeField] private int _cost;
        public int Cost => _cost;

        [SerializeField] private int _carryingCapacity;
        public int CarryingCapacity => _carryingCapacity;

        [SerializeField] private int _currentWeight;
        public int CurrentWeight => _currentWeight;

        [SerializeField] private float _speed;
        public float Speed => _speed;

        [SerializeField] private Health _health;
        public Health Health => _health;

        [SerializeField] private FishContainer _fishContainer;
        public FishContainer FishContainer => _fishContainer;

        public event Action<bool> OnMarketNearby;
        public event Action<bool> OnBoatShopNearby;
        public event Action<bool> OnFishingRodShopNearby;
        public event Action<bool> OnWorkshopNearby;

        public event Action OnShipInitialized;
        public event Action OnWeightChanged;

        SceneDataHandler SceneDataHandler => SceneDataHandler.Instance;

        #region UnityEvents
        private void Awake()
        {
            if (SceneDataHandler != null)
            {
                SceneDataHandler.AddToSceneObjList(this);
            }
        }

        private void Start()
        {
            if ((SceneDataHandler != null) && (!SceneDataHandler.HasSave()))
            {
                Initialize(_asset);
            }

            _fishContainer.OnFishCaught += TryChangeWeightAmount;
        }

        private void OnDestroy()
        {
            if (SceneDataHandler != null)
            {
                SceneDataHandler.RemoveFromSceneObjList(this);
            }

            _fishContainer.OnFishCaught -= TryChangeWeightAmount;
        }
        #endregion

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

        public void SendMarketMessage(bool value)
        {
            OnMarketNearby?.Invoke(value);
        }

        public void SendBoatShopMessage(bool value)
        {
            OnBoatShopNearby?.Invoke(value);
        }

        public void SendFishingRodShopMessage(bool value)
        {
            OnFishingRodShopNearby?.Invoke(value);
        }

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