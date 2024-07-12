using UnityEngine;
using System;

namespace ShipMotorika
{
    public class FishContainer : MonoBehaviour, ILoader, ISaver
    {
        [SerializeField] private int _totalFishWeight;
        public int Weight => _totalFishWeight;

        [SerializeField] private int _totalFishCost;
        public int Cost => _totalFishCost;

        public event Action<int> OnFishCaught;

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

        public void SetFishWeight(int weight)
        {
            if (weight > 0)
            {
                _totalFishWeight = weight;
            }
        }

        public void SetFishCost(int cost)
        {
            if (cost > 0)
            {
                _totalFishCost = cost;
            }
        }

        public void ClearContainer()
        {
            _totalFishWeight = 0;
            _totalFishCost = 0;
        }

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

            if (_totalFishCost < 0)
            {
                _totalFishCost = 0;
            }
        }

        public void Load()
        {
            var data = SceneDataHandler.Data;

            _totalFishCost = data.FishCost;
            _totalFishWeight = data.FishWeight;
        }

        public void Save()
        {
            var data = SceneDataHandler.Data;

            data.FishCost = _totalFishCost;
            data.FishWeight = _totalFishWeight;
        }
    }
}