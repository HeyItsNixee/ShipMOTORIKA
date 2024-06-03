using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Скрипт создания различных видов рыбы.
    /// </summary>
    [CreateAssetMenu]
    public class FishAsset : ScriptableObject
    {
        public Sprite Sprite;
        public int Cost;
        public int Weight;
    }
}