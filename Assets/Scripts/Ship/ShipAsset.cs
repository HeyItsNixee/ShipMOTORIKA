using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class ShipAsset : ScriptableObject
    {
        public Sprite GameSprite;
        public Sprite ShopImage;
        public string Name;
        public string Description;
        public float Speed;
        public int СarryingCapacity; // Грузоподъемность корабля
        public int Cost;
        public float ColliderX;
        public float ColliderY;
    }
}