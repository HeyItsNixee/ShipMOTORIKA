using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class FishingRodAsset : ScriptableObject
    {
        public Sprite GameSprite;
        public Sprite ShopImage;
        public string Name;
        public string Description;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}