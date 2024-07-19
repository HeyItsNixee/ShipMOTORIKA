using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Slider Slider => slider;
    [SerializeField] private Image fillImage;

    public void UpdateFillImage(float value)
    {
        fillImage.fillAmount = value;
    }
}
