using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Скрипт создания различных видов удочек.
    /// </summary>
    [CreateAssetMenu]
    public class FishingRodAsset : ScriptableObject
    {
        public Sprite Sprite;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}