using UnityEngine;
using System;

namespace ShipMotorika
{
    public class Money : MonoBehaviour, ILoader, ISaver
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;

        public event Action OnMoneyChanged;

        SceneDataHandler SceneDataHandler => SceneDataHandler.Instance;

        #region UnityEvents
        private void Awake()
        {
            if (SceneDataHandler != null)
            {
                SceneDataHandler.AddToSceneObjList(this);
            }          
        }

        private void OnDestroy()
        {
            if (SceneDataHandler != null)
            {
                SceneDataHandler.RemoveFromSceneObjList(this);
            }
        }
        #endregion

        public void SetCurrentMoney(int amount)
        {
            if (amount > 0)
            {
                _currentMoney = amount;

                OnMoneyChanged?.Invoke();
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
                }
            }
        }

        public void Load()
        {
            _currentMoney = SceneDataHandler.Data.Money;

            OnMoneyChanged?.Invoke();
        }

        public void Save()
        {
            SceneDataHandler.Data.Money = _currentMoney;
        }
    }
}