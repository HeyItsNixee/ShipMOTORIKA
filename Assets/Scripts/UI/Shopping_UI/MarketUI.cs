using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Интерфейс рынка.
    /// </summary>
    public class MarketUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _actionButton;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);
            
            _sellButton.onClick.AddListener(SellFish);
            _closeButton.onClick.AddListener(CloseMarket);
        }

        private void OnDestroy()
        {
            _sellButton.onClick.RemoveListener(SellFish);
            _closeButton.onClick.RemoveListener(CloseMarket);
        }
        #endregion

        private void CheckButtonAppearance()
        {
            if ((Player.Instance.Ship.FishContainer.Weight > 0) ||
                (Player.Instance.Ship.FishContainer.Cost > 0))
            {
                _sellButton.interactable = true;
            }
            else
            {
                _sellButton.interactable = false;
            }
        }

        private void SellFish()
        {
            Market.SellFish();

            CheckButtonAppearance();
        }

        private void CloseMarket()
        {
            _canvasPanel.SetActive(false);
            _actionButton.gameObject.SetActive(true);
            Player.Instance.GiveControlsToPlayer();
        }

        public void OpenMarket()
        {
            _canvasPanel.SetActive(true);
            _actionButton.gameObject.SetActive(false);
            Player.Instance.TakeControlsFromPlayer();

            CheckButtonAppearance();
        }
    }
}