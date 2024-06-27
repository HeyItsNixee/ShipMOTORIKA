using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Компонент магазина, представляющий апгрейд корабля для покупки игроком.
    /// </summary>
    public class ShipUpgrade : Upgrade
    {
        [Header("Additional upgrade information")]
        [SerializeField] private Text _speed;
        [SerializeField] private Text _carryingCopacity;
        [Space]
        [SerializeField] private ShipAsset _asset;

        private void Start()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            _image.sprite = _asset.ShopImage;
            _name.text = _asset.Name;
            _description.text = _asset.Description;           
            _upgradeCost = _asset.Cost;
            _cost.text = _upgradeCost.ToString();
            _speed.text = _asset.Speed.ToString();
            _carryingCopacity.text = _asset.СarryingCapacity.ToString();
        }

        public override void TryBuyUpgrade()
        {
            Player.Instance.Ship.Initialize(_asset);

            base.TryBuyUpgrade();
        }
    }
}