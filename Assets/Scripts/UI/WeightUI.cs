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

        private void Start()
        {
            UpdateImage();
            
            Player.Instance.Ship.OnWeightChanged += UpdateImage;
        }

        private void OnDestroy()
        {
            Player.Instance.Ship.OnWeightChanged -= UpdateImage;
        }

        private void UpdateImage()
        {
            var ship = Player.Instance.Ship;

            _image.fillAmount = (float) ship.CurrentWeight / ship.Carrying;
        }
    }
}