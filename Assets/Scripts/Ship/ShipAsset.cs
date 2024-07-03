using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Скрипт создания разных видов рыбы.
    /// </summary>
    [CreateAssetMenu]
    public class ShipAsset : ScriptableObject
    {
        public Sprite GameSprite;
        public Sprite ShopImage;
        public string Name;
        public string Description;
        public int Health;
        public float Speed;
        public int СarryingCapacity; // Грузоподъемность корабля
        public int Cost;
        public float ColliderX;
        public float ColliderY;
    }
}