using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ����� ������. ��������� ����� �������. 
    /// </summary>
    public sealed class Player : SingletonBase<Player>
    {
        /// <summary>
        /// ������� ������ � ������ ������.
        /// </summary>
        [SerializeField] private Ship _ship;
        public Ship Ship => _ship;

        /// <summary>
        /// ������ ������ � ������ ������
        /// </summary>
        [SerializeField] private FishingRod _fishingRod;
        public FishingRod FishingRod=> _fishingRod;

        /// <summary>
        /// ������� ������ � ������ ������
        /// </summary>
        [SerializeField] private Wallet _wallet;
        public Wallet Wallet => _wallet;
    }
}