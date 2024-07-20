using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Компонент магазина, представляющий апгрейд корабля для покупки игроком.
    /// </summary>
    public class ShipUpgrade : Upgrade
    {
        [SerializeField] private ShipAsset _asset;

        protected override void Initialize()
        {
            _upgradeCost = _asset.Cost;
            _cost.text = _upgradeCost.ToString();
        }

        public override void TryBuyUpgrade()
        {
            Player.Instance.Ship.Initialize(_asset);
            Player.Instance.Ship.Health.RestoreHealth();

            base.TryBuyUpgrade();
            gameObject.SetActive(false);
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