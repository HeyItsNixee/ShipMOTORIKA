using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Магазин, в котором игрок сможет купить апгрейды удочек.
    /// </summary>
    public class FishingRodShop : MonoBehaviour
    {
        private Collider2D _player;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;

                Player.Instance.Ship.SendFishingRodShopMessage(true);
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