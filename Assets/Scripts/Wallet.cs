using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    ///  ласс отвечающий за приход/расход денег игрока.
    /// </summary>
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _currentMoney;
        public int CurrentMoney => _currentMoney;

        public void TryChangeMoneyAmount(int amount)
        {            
            int currentMoney = _currentMoney + amount;

            if (currentMoney >= 0)
            {
                _currentMoney = currentMoney;
            }
        }
    }
}