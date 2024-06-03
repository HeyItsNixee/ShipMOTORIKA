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
        public string Name;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}