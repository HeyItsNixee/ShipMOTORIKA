using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Магазин, в котором игрок сможет купить апгрейды удочек.
    /// </summary>
    public class FishingRodShop : MonoBehaviour
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

                Player.Instance.Ship.SendFishingRodShopMessage(true);             

                if (_isRestorePoint)
                {
                    var restore = Player.Instance.ShipRestorer.RestorePoint;

                    if (restore != null)
                    {
                        restore.SetRestoreTransform(transform);
                    }
                }

                //SceneDataHandler.Instance?.Save();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _player) // Временное решение.
            {
                Player.Instance.Ship.SendFishingRodShopMessage(false);

                _player = null;
            }
        }
        #endregion
    }
}