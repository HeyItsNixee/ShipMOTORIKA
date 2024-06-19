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
            
            Player.Instance.Wallet.OnMoneyChanged += UpdateText;
        }

        private void OnDestroy()
        {
            Player.Instance.Wallet.OnMoneyChanged -= UpdateText;
        }
        #endregion

        private void UpdateText()
        {
            _text.text = Player.Instance.Wallet.CurrentMoney.ToString();
        }
    }
}