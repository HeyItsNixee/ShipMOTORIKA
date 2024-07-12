using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    public class ShipUpgrade : Upgrade
    {
        [Header("Additional upgrade information")]
        [SerializeField] private Text _health;
        [SerializeField] private Text _speed;
        [SerializeField] private Text _carryingCopacity;
        [Space]
        [SerializeField] private ShipAsset _asset;

        protected override void Initialize()
        {
            _image.sprite = _asset.ShopImage;
            _name.text = _asset.Name;
            _description.text = _asset.Description;
            _upgradeCost = _asset.Cost;
            _health.text = _asset.Health.ToString();
            _cost.text = _upgradeCost.ToString();
            _speed.text = _asset.Speed.ToString();
            _carryingCopacity.text = _asset.СarryingCapacity.ToString();
        }

        public override void TryBuyUpgrade()
        {
            Player.Instance.Ship.Initialize(_asset);
            Player.Instance.Ship.Health.RestoreHealth();

            base.TryBuyUpgrade();
        }

        public override void Load()
        { 
            var data = SceneDataHandler.Data;

            switch (_asset.name)
            {
                case "Ship_bronze":
                    _isAvailable = data.BronzeShipIsAvailable;
                    break;

                case "Ship_silver":
                    _isAvailable = data.SilverShipIsAvailable;
                    break;

                case "Ship_gold":
                    _isAvailable = data.GoldShipIsAvailable;
                    break;
            }
        }

        public override void Save()
        {
            var data = SceneDataHandler.Data;

            switch (_asset.name)
            {
                case "Ship_bronze":
                    data.BronzeShipIsAvailable = _isAvailable;
                    break;

                case "Ship_silver":
                    data.SilverShipIsAvailable = _isAvailable;
                    break;

                case "Ship_gold":
                    data.GoldShipIsAvailable = _isAvailable;
                    break;
            }
        }
    }
}