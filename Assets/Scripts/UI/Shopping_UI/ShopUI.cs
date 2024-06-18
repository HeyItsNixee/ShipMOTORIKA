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
        [SerializeField] private GameObject _shipsPanel;
        [SerializeField] private GameObject _fishingRodsPanel;

        [Header("Buttons")]      
        [SerializeField] private Button _shipsButton;
        [SerializeField] private Button _fishingRodsButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _actionButton;

        private GameObject _lastOpenedPanel;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);

            _shipsPanel.SetActive(false);
            _fishingRodsPanel.SetActive(false);
            _lastOpenedPanel = _shipsPanel;

            _shipsButton.onClick.AddListener(SwitchShipsPanel);
            _fishingRodsButton.onClick.AddListener(SwitchFishingRodsPanel);
            _closeButton.onClick.AddListener(CloseShop);

            Upgrade.OnUpgrade += UpdateButtons;
        }

        private void OnDestroy()
        {
            _shipsButton.onClick.RemoveListener(SwitchShipsPanel);
            _fishingRodsButton.onClick.RemoveListener(SwitchFishingRodsPanel);
            _closeButton.onClick.RemoveListener(CloseShop);

            Upgrade.OnUpgrade -= UpdateButtons;
        }
        #endregion

        private void SwitchShipsPanel()
        {
            _fishingRodsPanel.SetActive(false);
            _shipsPanel.SetActive(true);
            _lastOpenedPanel = _shipsPanel;
        }

        private void SwitchFishingRodsPanel()
        {
            _shipsPanel.SetActive(false);
            _fishingRodsPanel.SetActive(true);
            _lastOpenedPanel = _fishingRodsPanel;
        }

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
            _inputCanvas.gameObject.SetActive(true);

            _shipsPanel.SetActive(false);
            _fishingRodsPanel.SetActive(false);
            _actionButton.gameObject.SetActive(true);

            Player.Instance.GiveControlsToPlayer();
        }

        public void OpenShop()
        {
            _canvasPanel.SetActive(true);
            _inputCanvas.gameObject.SetActive(false);
            
            _lastOpenedPanel.SetActive(true);
            _actionButton.gameObject.SetActive(false);

            Player.Instance.TakeControlsFromPlayer();

            UpdateButtons();
        }
    }
}