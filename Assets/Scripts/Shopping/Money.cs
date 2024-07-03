using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Класс отвечающий за приход или расход денег игрока.
    /// </summary>
    public class Money : MonoBehaviour
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;

        public event Action OnMoneyChanged;

        #region UnityEvents
        private void Start()
        {
            PlayerData.LoadMoney();
        }
        #endregion

        public void SetCurrentMoney(int amount)
        {
            if (amount > 0)
            {
                _currentMoney = amount;

                OnMoneyChanged?.Invoke();

                PlayerData.SaveMoney();
            }
        }

        public void TryChangeMoneyAmount(int amount)
        {
            if (amount != 0)
            {
                int currentMoney = _currentMoney + amount;

                if (currentMoney >= 0)
                {
                    _currentMoney = currentMoney;

                    OnMoneyChanged?.Invoke();

                    PlayerData.SaveMoney();
                }
            }
        }
    }
}