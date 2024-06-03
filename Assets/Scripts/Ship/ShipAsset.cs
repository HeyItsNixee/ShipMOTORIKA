using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class ShipAsset : ScriptableObject
    {
        public Sprite Sprite;
        public int Cost;
        public int Сarrying; // Грузоподъемность
    }
}