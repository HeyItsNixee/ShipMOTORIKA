using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Класс отвечающий за приход или расход денег игрока.
    /// </summary>
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;

        public event Action OnMoneyChanged;

        public void TryChangeMoneyAmount(int amount)
        {            
            int currentMoney = _currentMoney + amount;

            if (currentMoney >= 0)
            {
                _currentMoney = currentMoney;

                OnMoneyChanged?.Invoke();
            }
        }
    }
}