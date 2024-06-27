using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Восстанавливает корабль игрока после его уничтожения.
    /// </summary>
    public class PlayerShipRestorer : MonoBehaviour
    {
        #region UnityEvents
        private void Start()
        {
            Player.Instance.Ship.Health.OnDeath += RestoreShip;
        }

        private void OnDestroy()
        {
            Player.Instance.Ship.Health.OnDeath -= RestoreShip;
        }
        #endregion

        private void RestoreShip()
        {
            var ship = Player.Instance.Ship;
            var position = Player.Instance.RestorePoint.Position;

            ship.gameObject.transform.position = position.position;
            ship.FishContainer.ClearContainer();
        }
    }
}