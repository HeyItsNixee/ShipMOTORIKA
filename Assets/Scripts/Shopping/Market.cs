using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Рынок, на котором игрок может продать рыбу и купить апгрейды.
    /// </summary>
    public class Market : MonoBehaviour
    {
        private Collider2D _player = null;

        #region UnityEvents
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) // Временное решение.
            {
                _player = collision;               
                Player.Instance.Ship.SendMarketMessage(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision == _player) // Временное решение.
            {
                _player = null;            
                Player.Instance.Ship.SendMarketMessage(false);
            }
        }
        #endregion

        public static void SellFish()
        {
            int weight = Player.Instance.Ship.FishContainer.Weight;
            int money = Player.Instance.Ship.FishContainer.Cost;

            Player.Instance.Ship.TryChangeWeightAmount(-weight);
            Player.Instance.Wallet.TryChangeMoneyAmount(money);
            Player.Instance.Ship.FishContainer.ClearContainer();
        }
    }
}