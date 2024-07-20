using UnityEngine;
using UnityEngine.UI;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Компонент магазина.
    /// </summary>
    public abstract class Upgrade : MonoBehaviour, ILoader, ISaver//, IInitializer
    {
        [SerializeField] protected Text _cost;

        public static event Action OnUpgrade;

        protected int _upgradeCost;
        protected bool _isAvailable = true;

        #region UnityEvents
        private void Awake()
        {
            SceneDataHandler.Loaders.Add(this);
            SceneDataHandler.Savers.Add(this);
        }

        protected void Start()
        {
            Initialize();
        }
        #endregion

        public virtual void TryBuyUpgrade()
        {
            Player.Instance.Money.TryChangeMoneyAmount(-Math.Abs(_upgradeCost));

            _isAvailable = false;

            OnUpgrade?.Invoke();

            SceneDataHandler.Instance?.Save();
        }

        protected virtual void Initialize() { }

        public virtual void Load() { }

        public virtual void Save() { }
    }
}