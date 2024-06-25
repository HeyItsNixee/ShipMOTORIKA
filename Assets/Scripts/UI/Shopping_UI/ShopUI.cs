using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Интерфейс магазина.
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Canvas _inputCanvas;
        
        [Header("Upgrades")]    
        [SerializeField] private Upgrade[] _upgrades;
        [SerializeField] private GameObject _upgradesPanel;

        [Header("Buttons")]      
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _actionButton;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);
            _upgradesPanel.SetActive(false);

            _closeButton.onClick.AddListener(CloseShop);

            Upgrade.OnUpgrade += UpdateButtons;
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(CloseShop);

            Upgrade.OnUpgrade -= UpdateButtons;
        }
        #endregion

        private void UpdateButtons()
        {
            foreach (var upgrade in _upgrades)
            {
                upgrade.UpdateButton();
            }
        }

        private void CloseShop()
        {
            _canvasPanel.SetActive(false);
            _upgradesPanel.SetActive(false);

            _inputCanvas.gameObject.SetActive(true);
            _actionButton.gameObject.SetActive(true);

            Player.Instance.GiveControlsToPlayer();
        }

        public void OpenShop()
        {
            _canvasPanel.SetActive(true);
            _upgradesPanel.SetActive(true);

            _inputCanvas.gameObject.SetActive(false);
            _actionButton.gameObject.SetActive(false);

            Player.Instance.TakeControlsFromPlayer();

            UpdateButtons();
        }
    }
}