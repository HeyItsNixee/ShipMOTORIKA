using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Магазин, в котором игрок сможет купить апгрейды корабля и удочек.
    /// </summary>
    public class Shop : MonoBehaviour
    {
        private Collider2D _player = null;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;
                Player.Instance.Ship.SendShopMessage(true);
            }
        }

        //private void OnTriggerStay2D(Collider2D collision) // Для дебага.
        //{
        //    if (collision == _player)
        //    {
        //        Player.Instance.Ship.SendShopMessage(true);
        //    }
        //}

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _player) // Временное решение.
            {
                _player = null;
                
                if (Player.Instance) // Вариант решения ошибки NullReference.
                {
                    Player.Instance.Ship.SendShopMessage(false);
                }
                //Player.Instance.Ship.SendShopMessage(false);
            }
        }
        #endregion
    }
}