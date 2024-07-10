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
        [Header("Upgrade information")]
        [SerializeField] protected Image _image;
        [SerializeField] protected Text _name;
        [SerializeField] protected Text _description;
        [SerializeField] protected Text _cost;

        [Header("\"Buy Button\" parameters")]
        [SerializeField] protected Button _button;
        [SerializeField] protected Text _buttonText;

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
            UpdateButton();
        }
        #endregion

        public virtual void UpdateButton()
        {
            if (_isAvailable)
            {
                int money = Player.Instance.Money.CurrentMoney;

                if (money >= _upgradeCost)
                {
                    _button.interactable = true;
                    _buttonText.text = "Купить"; //Временно!
                }
                else
                {
                    _button.interactable = false;
                    _buttonText.text = "Нет денег"; //Временно!
                }
            }
            else
            {
                _button.interactable = false;
                _buttonText.text = "Приобретено"; //Временно!
            }
        }

        public virtual void TryBuyUpgrade()
        {
            Player.Instance.Money.TryChangeMoneyAmount(-Math.Abs(_upgradeCost));

            _isAvailable = false;

            UpdateButton();

            OnUpgrade?.Invoke();

            SceneDataHandler.Instance?.Save();
        }

        protected virtual void Initialize() { }

        public virtual void Load() { }

        public virtual void Save() { }
    }
}