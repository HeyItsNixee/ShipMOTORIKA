using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    ///  нопка при нажатии на которой определ€етс€ результат мини-игры FishingChallenge.
    /// </summary>
    public class CatchFishButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private FishingChallengeButton _fishingChallengeButton;
        [SerializeField] private CaughtFishImage _caughtFishImage;

        #region UnityEvents
        private void Start()
        {
            _button.gameObject.SetActive(false);

            _button.onClick.AddListener(CatchFish);
            _fishingChallengeButton.Button.onClick.AddListener(ActivateButton);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(CatchFish);
            _fishingChallengeButton.Button.onClick.RemoveListener(ActivateButton);
        }
        #endregion;

        private void ActivateButton()
        {
            _button.gameObject.SetActive(true);
        }

        private void CatchFish()
        {
            FishingChallenge.Instance.TryCatchFish();          
            _button.gameObject.SetActive(false);
            _caughtFishImage.SetActive(true);
        }
    }
}