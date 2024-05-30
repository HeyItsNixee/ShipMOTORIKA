using UnityEngine;

namespace ShipMotorica
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField] private FishingRod _fishingRod;
        [SerializeField] private float _fishingDistance;
    }
}