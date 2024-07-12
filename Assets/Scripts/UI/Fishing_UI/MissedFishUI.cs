using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    public class MissedFishUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);

            _button.onClick.AddListener(DoOnButtonClick);
            FishingChallenge.Instance.OnTryCatchFish += DoOnTryCatchFish;
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(DoOnButtonClick);
            FishingChallenge.Instance.OnTryCatchFish -= DoOnTryCatchFish;
        }
        #endregion

        private void DoOnButtonClick()
        {
            _canvasPanel.SetActive(false);

            FishingChallenge.Instance.Deactivate();
        }

        private void DoOnTryCatchFish(bool success)
        {
            if (!success)
            {
                _canvasPanel.SetActive(true);
            }
        }
    }
}