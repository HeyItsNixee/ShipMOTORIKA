using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [Space]
    [SerializeField] private float maxValue = 100f;


    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateFillImage);
    }

    private void UpdateFillImage(float value)
    {
        fillImage.fillAmount = value;
    }
}
