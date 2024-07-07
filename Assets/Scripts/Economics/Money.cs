using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Класс отвечающий за приход или расход денег игрока.
    /// </summary>
    public class Money : MonoBehaviour, ILoader, ISaver
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;

        public event Action OnMoneyChanged;

        #region UnityEvents
        private void Awake()
        {
            PersistentDataHandler.Loaders.Add(this);
            PersistentDataHandler.Savers.Add(this);
        }
        #endregion

        public void SetCurrentMoney(int amount)
        {
            if (amount > 0)
            {
                _currentMoney = amount;

                OnMoneyChanged?.Invoke();

                Save(); // Attention!
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

                    Save(); // Attention!
                }
            }
        }

        public void Load()
        {
            
        }

        public void Save()
        {
            
        }
    }
}