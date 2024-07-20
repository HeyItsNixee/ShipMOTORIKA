using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Компонент магазина, представляющий апгрейд удочки для покупки игроком.
    /// </summary>
    public class FishingRodUpgrade : Upgrade
    {
        [SerializeField] private FishingRodAsset _asset;

        protected override void Initialize()
        {
            _upgradeCost = _asset.Cost;
            _cost.text = _asset.Cost.ToString();
        }

        public override void TryBuyUpgrade()
        {
            Player.Instance.FishingRod.Initialize(_asset);

            base.TryBuyUpgrade();
            gameObject.SetActive(false);
        }

        public override void Load()
        {
            var data = SceneDataHandler.Data;

            switch (_asset.name)
            {
                case "FishingRod_bronze":
                    _isAvailable = data.BronzeFishingRodIsAvailable;
                    break;

                case "FishingRod_silver":
                    _isAvailable = data.SilverFishingRodIsAvailable;
                    break;

                case "FishingRod_gold":
                    _isAvailable = data.GoldFishingRodIsAvailable;
                    break;
            }
        }

        public override void Save()
        {
            var data = SceneDataHandler.Data;

            switch (_asset.name)
            {
                case "FishingRod_bronze":
                    data.BronzeFishingRodIsAvailable = _isAvailable;
                    break;

                case "FishingRod_silver":
                    data.SilverFishingRodIsAvailable = _isAvailable;
                    break;

                case "FishingRod_gold":
                    data.GoldFishingRodIsAvailable = _isAvailable;
                    break;
            }
        }
    }
}