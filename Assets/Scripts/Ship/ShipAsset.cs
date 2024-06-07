using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class ShipAsset : ScriptableObject
    {
        public Sprite Sprite;
        public string Name;
        public string Description;
        public int Cost;
        public int СarryingCapacity; // Грузоподъемность корабля
    }
}