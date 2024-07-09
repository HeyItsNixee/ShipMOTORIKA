using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Мастерская, где можно отремонтировать лодку игрока.
    /// </summary>
    public class Workshop : MonoBehaviour
    {
        /// <summary>
        /// Если true (и был последним), здесь восстановится корабль игрока после уничтожения.
        /// </summary>
        [SerializeField] private bool _isRestorePoint;

        /// <summary>
        /// Стоимость полной починки корабля. 
        /// </summary>
        [SerializeField] private int _repairCost;

        private static Health _health;

        private static int _cost;

        private Collider2D _player;

        #region UnityEvents
        private void Start()
        {
            _health = Player.Instance.Ship.Health;
            _cost = _repairCost;
        }

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

        /// <summary>
        /// Стоимость починки корабля с учетом повреждений.
        /// </summary>
        public static int CurrentRepairCost()
        {
            if (_health.CurrentHealth < _health.MaxHealth)
            {
                int currentRepairCost = _cost * _health.CurrentHealth / _health.MaxHealth;
                return currentRepairCost;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Отремонтировать корабль за определенную стоимость.
        /// </summary>
        public static void TryRepairShip()
        {
            if (CurrentRepairCost() > 0)
            {
                var money = Player.Instance.Money;

                if (money.CurrentMoney >= CurrentRepairCost())
                {
                    money.TryChangeMoneyAmount(-Mathf.Abs(CurrentRepairCost()));

                    _health.RestoreHealth();

                    SceneDataHandler.Instance?.Save();
                }
            }
        }
    }
}