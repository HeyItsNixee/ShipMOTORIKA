using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Класс игрока. Переходит между сценами. 
    /// </summary>
    public sealed class Player : SingletonBase<Player>
    {
        /// <summary>
        /// Корабль игрока в данный момент.
        /// </summary>
        [SerializeField] private Ship _ship;
        public Ship Ship => _ship;

        /// <summary>
        /// Удочка игрока в данный момент
        /// </summary>
        [SerializeField] private FishingRod _fishingRod;
        public FishingRod FishingRod=> _fishingRod;

        /// <summary>
        /// Кошелек игрока в данный момент
        /// </summary>
        [SerializeField] private Wallet _wallet;
        public Wallet Wallet => _wallet;
    }
}