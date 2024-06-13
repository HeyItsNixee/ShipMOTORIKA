using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Склад для пойманной рыбы на корабле.
    /// </summary>
    public class FishContainer : MonoBehaviour
    {
        /// <summary>
        /// Суммарный вес пойманной рыбы.
        /// </summary>
        [SerializeField] private int _totalFishWeight;
        public int Weight => _totalFishWeight;

        /// <summary>
        /// Суммарна¤ стоимость пойманной рыбы.
        /// </summary>
        [SerializeField] private int _totalFishCost;
        public int Cost => _totalFishCost;
      
        public event Action<int> OnFishCaught;

        public void ChangeWeightAmount(int amount)
        {
            _totalFishWeight += amount;

            if (_totalFishWeight < 0)
            {
                _totalFishWeight = 0;
            }

            OnFishCaught(amount);
        }

        public void ChangeCostAmount(int amount)
        {
            _totalFishCost += amount;

            if ( _totalFishCost < 0)
            {
                _totalFishCost = 0;
            }
        }

        public void ClearContainer()
        {
            _totalFishWeight = 0;
            _totalFishCost = 0;
        }
    }
}