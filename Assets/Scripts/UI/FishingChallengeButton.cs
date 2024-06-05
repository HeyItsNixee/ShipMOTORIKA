using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Кнопка, которая появляется, если игрок находится в радиусе действия удочки от места ловли рыбы. Временный скрипт.
    /// </summary>
    public class FishingChallengeButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public Button Button => _button;

        private void Start()
        {        
            _button.interactable = false;
            _button.gameObject.SetActive(false);
                 
            _button.onClick.AddListener(StartFishingChallenge);
            Player.Instance.FishingRod.OnFishingPlaceNearby += ActivateButton;
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(StartFishingChallenge);
            Player.Instance.FishingRod.OnFishingPlaceNearby -= ActivateButton;
        }

        private void ActivateButton(bool value)
        {
            _button.gameObject.SetActive(value);
            _button.interactable = value;
        }

        private void StartFishingChallenge()
        {
            FishingChallenge.Instance.Activate();
            ActivateButton(false);
        }
    }
}