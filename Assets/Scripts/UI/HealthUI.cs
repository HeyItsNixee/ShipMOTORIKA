using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Отображает здоровье корабля игрока в интерфейсе.
    /// </summary>
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        #region UnityEvents
        private void Start()
        {
            UpdateImage();
            
            Player.Instance.Ship.OnShipInitialized += UpdateImage;
            Player.Instance.Ship.Health.OnHealthChanged += UpdateImage;
        }

        private void OnDestroy()
        {
            Player.Instance.Ship.OnShipInitialized -= UpdateImage;
            Player.Instance.Ship.Health.OnHealthChanged -= UpdateImage;
        }
        #endregion

        private void UpdateImage()
        {
            var health = Player.Instance.Ship.Health;

            if (health.MaxHealth > 0)
            {
                _image.fillAmount = (float)health.CurrentHealth / health.MaxHealth;
            }
            else
            {
                _image.fillAmount = 0f;
            }
        }
    }
}