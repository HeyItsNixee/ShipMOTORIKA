using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Открывает информацию о пойманной рыбе в интерфейсе при успешном прохождении мини-игры FishingChallenge.
    /// </summary>
    public class CaughtFishUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private FishCard _fishCard;
        [SerializeField] private Image _image;
        [SerializeField] private Button _accept;
        [SerializeField] private Button _decline;
        [SerializeField] private Button _info;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);
            _fishCard.gameObject.SetActive(false);

            _accept.onClick.AddListener(DoOnAccept);
            _decline.onClick.AddListener(DoOnDecline);
            _info.onClick.AddListener(ShowFishInformation); 
            
            FishAlbum.Instance.OnFirstCatch += ShowFishInformation;
            FishingChallenge.Instance.OnTryCatchFish += ActivatePanel;
            Player.Instance.FishingRod.OnFishAssigned += SetFishImage;
        }

        private void OnDestroy()
        {
            _accept.onClick.RemoveListener(DoOnAccept);
            _decline.onClick.RemoveListener(DoOnDecline);
            _info.onClick.RemoveListener(ShowFishInformation);

            FishAlbum.Instance.OnFirstCatch -= ShowFishInformation;
            FishingChallenge.Instance.OnTryCatchFish -= ActivatePanel;
            Player.Instance.FishingRod.OnFishAssigned -= SetFishImage;
        }
        #endregion

        private void ActivatePanel(bool success)
        {
            if (success)
            {
                _canvasPanel.SetActive(true);
            }
        }

        private void SetFishImage()
        {
            if (Player.Instance.FishingRod.CaughtFish != null)
            {
                _image.sprite = Player.Instance.FishingRod.CaughtFish.Sprite.sprite;
                //_image.SetNativeSize(); // Attention! Only for Debug!

                FishAlbum.Instance.CheckCardInfo(); // Attention!
            }
        }

        /// <summary>
        /// Показать карточку рыбы.
        /// </summary>
        private void ShowFishInformation()
        {
            _fishCard.gameObject.SetActive(true);
            _fishCard.Initialize();
        }

        /// <summary>
        /// Взять рыбу.
        /// </summary>
        public void DoOnAccept()
        {
            _canvasPanel.SetActive(false);

            Player.Instance.FishingRod.TryPutFishInShip();
            FishingChallenge.Instance.Deactivate();
        }

        /// <summary>
        /// Отпустить рыбу.
        /// </summary>
        public void DoOnDecline()
        {
            _canvasPanel.SetActive(false);

            Player.Instance.FishingRod.AssignFish(null);
            FishingChallenge.Instance.Deactivate();
        }
    }
}