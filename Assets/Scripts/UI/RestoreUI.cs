using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    public class RestoreUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Canvas _inputCanvas;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _actionButton;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);

            _continueButton.onClick.AddListener(Continue);
            Player.Instance.Ship.Health.OnDeath += ShowMessage;
        }

        private void OnDestroy()
        {
            _continueButton.onClick.RemoveListener(Continue);
            Player.Instance.Ship.Health.OnDeath -= ShowMessage;
        }
        #endregion

        private void Continue()
        {
            _canvasPanel.SetActive(false);

            _inputCanvas.gameObject.SetActive(true);
            _actionButton.gameObject.SetActive(true);

            Player.Instance.ShipRestorer.RestoreShip();
            Player.Instance.GiveControlsToPlayer();
        }

        private void ShowMessage()
        {
            _canvasPanel.SetActive(true);

            _inputCanvas.gameObject.SetActive(false);
            _actionButton.gameObject.SetActive(false);

            Player.Instance.TakeControlsFromPlayer();
        }
    }
}