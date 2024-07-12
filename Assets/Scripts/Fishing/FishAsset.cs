using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class FishAsset : ScriptableObject
    {
        public Sprite Sprite;
        public string Name;
        public string Description;
        public int Cost;
        public int Weight;
    }
}