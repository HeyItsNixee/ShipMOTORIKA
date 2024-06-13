using UnityEngine;
using UnityEngine.UI;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Компонент магазина.
    /// </summary>
    public abstract class Upgrade : MonoBehaviour
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

        #region UnityEvrnts
        private void Start()
        {
            Initialize();
        }
        #endregion

        protected virtual void Initialize() { }

        public virtual void TryBuyUpgrade()
        {
            Player.Instance.Wallet.TryChangeMoneyAmount(-Math.Abs(_upgradeCost));

            _isAvailable = false;

            OnUpgrade?.Invoke();
        }

        public virtual void UpdateButton()
        {
            if (_isAvailable)
            {
                int money = Player.Instance.Wallet.CurrentMoney;

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
    }
}