using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Отображает деньги игрока в интерфейсе.
    /// </summary>
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private Text _text;

        #region UnityEvents
        private void Start()
        {
            UpdateText();
            
            Player.Instance.Money.OnMoneyChanged += UpdateText;
        }

        private void OnDestroy()
        {
            Player.Instance.Money.OnMoneyChanged -= UpdateText;
        }
        #endregion

        private void UpdateText()
        {
            if (Player.Instance.Money.CurrentMoney <= 999)
                _text.text = Player.Instance.Money.CurrentMoney.ToString();
            else
            {
                if (Player.Instance.Money.CurrentMoney > 999 && Player.Instance.Money.CurrentMoney <= 9999)
                {
                    _text.text = (Player.Instance.Money.CurrentMoney / 1000).ToString() 
                        + "." + ((Player.Instance.Money.CurrentMoney - (Player.Instance.Money.CurrentMoney / 1000) * 1000) / 100) + "K";
                }
            }
        }
    }
}