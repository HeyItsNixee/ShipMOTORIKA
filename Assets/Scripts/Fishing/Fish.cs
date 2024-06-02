using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Название говорит само за себя. Рыба.
    /// </summary>
    public class Fish : MonoBehaviour
    {
        /// <summary>
        /// Визуальное отображение рыбы в интерфейсе
        /// </summary>
        [SerializeField] private SpriteRenderer _sprite;
        public SpriteRenderer Sprite => _sprite;

        /// <summary>
        /// Стоимость рыбы при продаже
        /// </summary>
        private int _cost;
        public int Cost => _cost;

        /// <summary>
        /// Вес пойманной рыбы. Суммарный вес всей пойманной рыбы не может превышать грузоподъемность корабля.
        /// </summary>
        private int _weight;
        public int Weight => _weight;   

        /// <summary>
        /// В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _cost = asset.Cost;
            _weight = asset.Weight;
        }
    }
}