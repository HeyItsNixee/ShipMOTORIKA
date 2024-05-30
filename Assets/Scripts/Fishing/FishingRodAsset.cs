using UnityEngine;

namespace ShipMotorica
{
    [CreateAssetMenu]
    public class FishingRodAsset : ScriptableObject
    {
        public Sprite Sprite;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}