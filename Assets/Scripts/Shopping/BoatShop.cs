using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Магазин, в котором игрок сможет купить апгрейды корабля и удочек.
    /// </summary>
    public class BoatShop : MonoBehaviour
    {
        /// <summary>
        /// Если true (и был последним), здесь восстановится корабль игрока после уничтожения.
        /// </summary>
        [SerializeField] private bool _isRestorePoint;

        private Collider2D _player;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _player) // Временное решение.
            {
                Player.Instance.Ship.SendBoatShopMessage(false);

                _player = null;
            }
        }
        #endregion
    }
}