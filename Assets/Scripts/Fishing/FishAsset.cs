using UnityEngine;

namespace ShipMotorica
{
    [CreateAssetMenu]
    public class FishAsset : ScriptableObject
    {
        public Sprite Sprite;
        public float Radius;
        public int Cost;
    }
}