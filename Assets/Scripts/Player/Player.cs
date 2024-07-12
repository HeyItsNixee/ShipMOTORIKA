using UnityEngine;

namespace ShipMotorika
{
    public sealed class Player : SingletonBase<Player>
    {
        [SerializeField] private Ship _ship;
        public Ship Ship => _ship;

        [SerializeField] private FishingRod _fishingRod;
        public FishingRod FishingRod=> _fishingRod;

        [SerializeField] private Money _money;
        public Money Money => _money;

        [SerializeField] private PlayerController _playerController;
        public PlayerController PlayerController => _playerController;

        [SerializeField] private ShipRestorer _shipRestorer;
        public ShipRestorer ShipRestorer => _shipRestorer;

        public void GiveControlsToPlayer()
        {
            _playerController.enabled = true;
            _playerController.AllowMovement();
        }
        
        public void TakeControlsFromPlayer()
        {
            _playerController.ProhibitMovement();
            _playerController.enabled = false;
        }
    }
}