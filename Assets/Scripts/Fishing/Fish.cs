using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Название говорит само за себя - рыба.
    /// </summary>
    public class Fish : MonoBehaviour
    {
        /// <summary>
        /// Визуальное отображение рыбы в интерфейсе
        /// </summary>
        [SerializeField] private SpriteRenderer _sprite;
        public SpriteRenderer Sprite => _sprite;

        /// <summary>
        /// Название рыбы. Для элементов интерфейса.
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;

        /// <summary>
        /// Описание рыбы для записей в коллекцию.
        /// </summary>
        [SerializeField] private string _description;
        public string Description => _description;

        /// <summary>
        /// Стоимость рыбы при продаже
        /// </summary>
        [SerializeField] private int _cost;
        public int Cost => _cost;

        /// <summary>
        /// Вес пойманной рыбы. Суммарный вес всей пойманной рыбы не может превышать грузоподъемность корабля.
        /// </summary>
        [SerializeField] private int _weight;
        public int Weight => _weight;   

        /// <summary>
        /// В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _name = asset.Name; 
            _description = asset.Description;
            _cost = asset.Cost;
            _weight = asset.Weight;
        }
    }
}