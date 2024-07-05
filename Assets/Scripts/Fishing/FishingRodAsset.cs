using System;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Скрипт создания разных видов удочек.
    /// </summary>
    [CreateAssetMenu]
    [Serializable]
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