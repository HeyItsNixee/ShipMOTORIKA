using UnityEngine;

namespace ShipMotorika
{
    public sealed class Player : SingletonBase<Player>
    {
        [SerializeField] private FishingRod _fishingRod;
        public FishingRod FishingRod=> _fishingRod;
    }
}