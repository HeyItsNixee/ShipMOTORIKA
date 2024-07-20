using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Интерфейс магазина.
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
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
            _upgradesPanel.gameObject.SetActive(false);

            _closeButton.onClick.AddListener(CloseShop);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(CloseShop);
        }
        #endregion

        public void CloseShop()
        {
            _upgradesPanel.gameObject.SetActive(false);

            _inputCanvas.gameObject.SetActive(true);
            _actionButton.gameObject.SetActive(true);

            Player.Instance.GiveControlsToPlayer();
            PauseList.Instance.gameObject.SetActive(true);
        }

        public void OpenShop()
        {
            //_upgradesPanel.SetActive(true);


            _inputCanvas.gameObject.SetActive(false);
            _actionButton.gameObject.SetActive(false);

            Player.Instance.TakeControlsFromPlayer();
            PauseList.Instance.gameObject.SetActive(false);
        }
    }
}