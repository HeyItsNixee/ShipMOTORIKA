using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    public class MarketUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Canvas _inputCanvas;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _actionButton;
        [SerializeField] private Text _text;

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
            UpdateText();
        }

        private void UpdateText()
        {
            var cost = Player.Instance.Ship.FishContainer.Cost;
            var weight = Player.Instance.Ship.FishContainer.Weight;

            _text.text = $"Поймано {weight} кг рыбы общей стоимостью {cost} монет"; // Временный текст.
        }

        private void CloseMarket()
        {
            _canvasPanel.SetActive(false);

            _inputCanvas.gameObject.SetActive(true);
            _actionButton.gameObject.SetActive(true);

            Player.Instance.GiveControlsToPlayer();
        }

        public void OpenMarket()
        {
            _canvasPanel.SetActive(true);

            _inputCanvas.gameObject.SetActive(false);
            _actionButton.gameObject.SetActive(false);

            Player.Instance.TakeControlsFromPlayer();

            CheckButtonAppearance();
            UpdateText();
        }
    }
}