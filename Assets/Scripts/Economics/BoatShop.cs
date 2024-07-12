using UnityEngine;

namespace ShipMotorika
{
    public class BoatShop : MonoBehaviour
    {
        [SerializeField] private bool _isRestorePoint;

        private Collider2D _player;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;

                Player.Instance.Ship.SendBoatShopMessage(true);

                if (_isRestorePoint)
                {
                    var restore = Player.Instance.ShipRestorer.RestorePoint;

                    if (restore != null)
                    {
                        restore.SetRestoreTransform(transform);
                    }
                }
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