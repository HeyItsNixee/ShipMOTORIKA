using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Кнопки результата мини-игры FishingChalllenge. В зависимости от успеха прохождения показывает один из вариантов: Провал/Успех.
    /// </summary>
    public class FishingChallengeResultButtons : MonoBehaviour
    {       
        [SerializeField] private Button _successButton;
        [SerializeField] private Button _failureButton;
        [SerializeField] private CaughtFishImage _caughtFishImage;

        #region UnityEvent;
        private void Start()
        {       
            _successButton.gameObject.SetActive(false);
            _failureButton.gameObject.SetActive(false);

            _successButton.onClick.AddListener(CloseButtons);
            _failureButton.onClick.AddListener(CloseButtons);
           
            FishingChallenge.Instance.OnTryCatchFish += SetButtonActive;
        }

        private void OnDestroy()
        {
            _successButton.onClick.AddListener(CloseButtons);
            _failureButton.onClick.AddListener(CloseButtons);

            FishingChallenge.Instance.OnTryCatchFish -= SetButtonActive;
        }
        #endregion

        private void SetButtonActive(bool success)
        {
            _successButton.gameObject.SetActive(success);
            _failureButton.gameObject.SetActive(!success);
        }

        private void CloseButtons()
        {
            _successButton.gameObject.SetActive(false);
            _failureButton.gameObject.SetActive(false);

            _caughtFishImage.SetActive(false);

            FishingChallenge.Instance.Deactivate();        
        }
    }
}