using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class FishAsset : ScriptableObject
    {
        public Sprite Sprite;
        public int Cost;
        public int Weight;
    }
}