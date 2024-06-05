using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Показывает в интерфейсе изображение пойманной рыбы.
    /// </summary>
    public class CaughtFishImage : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Start()
        {
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            _image.enabled = false;

            if (Player.Instance.FishingRod.LastCaughtFish != null)
            {
                _image.enabled = value;
                _image.sprite = Player.Instance.FishingRod.LastCaughtFish.Sprite.sprite;
                _image.SetNativeSize();
            }
        }
    }
}