using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Мастерская, где можно отремонтировать лодку игрока.
    /// </summary>
    public class Workshop : MonoBehaviour
    {
        private Collider2D _player;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;

                Player.Instance.Ship.SendWorkshopMessage(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _player) // Временное решение.
            {
                Player.Instance.Ship.SendWorkshopMessage(false);

                _player = null;
            }
        }
        #endregion

        public static void RepairShip()
        {
            // Some code.
        }
    }
}