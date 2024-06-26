using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Интерфейс мастерской.
    /// </summary>
    public class WorkshopUI : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasPanel;
        [SerializeField] private Canvas _inputCanvas;
        [SerializeField] private Button _repairButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _actionButton;

        #region UnityEvents
        private void Start()
        {
            _canvasPanel.SetActive(false);

            _repairButton.onClick.AddListener(RepairShip);
            _closeButton.onClick.AddListener(CloseWorkshop);
        }

        private void OnDestroy()
        {
            _repairButton.onClick.RemoveListener(RepairShip);
            _closeButton.onClick.RemoveListener(CloseWorkshop);
        }
        #endregion

        private void CheckButtonAppearance()
        {
            //if () // Проверка,на то, что текущее здоровье корабля меньше максимального. И на то, есть ли деньги на починку.
            //{
            //    _repairButton.interactable = true;
            //}
            //else
            //{
            //    _repairButton.interactable = false;
            //}
        }

        private void RepairShip()
        {
            Workshop.RepairShip();

            CheckButtonAppearance();
        }

        private void CloseWorkshop()
        {
            _canvasPanel.SetActive(false);
            _inputCanvas.gameObject.SetActive(true);

            _actionButton.gameObject.SetActive(true);
            Player.Instance.GiveControlsToPlayer();
        }

        public void OpenWorkshop()
        {
            _canvasPanel.SetActive(true);
            _inputCanvas.gameObject.SetActive(false);

            _actionButton.gameObject.SetActive(false);
            Player.Instance.TakeControlsFromPlayer();

            CheckButtonAppearance();
        }
    }
}