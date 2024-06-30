using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Отображает текущий вес корабля в интерфейсе.
    /// </summary>
    public class WeightUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        #region UnityEvents
        private void Awake()
        {
            _image.fillAmount = 0f;
        }

        private void Start()
        {
            Player.Instance.Ship.OnShipInitialized += UpdateImage;
            Player.Instance.Ship.OnWeightChanged += UpdateImage;  
        }

        private void OnDestroy()
        {
            Player.Instance.Ship.OnShipInitialized -= UpdateImage;
            Player.Instance.Ship.OnWeightChanged -= UpdateImage;
        }
        #endregion

        private void UpdateImage()
        {
            var ship = Player.Instance.Ship;

            _image.fillAmount = (float) ship.CurrentWeight / ship.CarryingCapacity;
        }
    }
}