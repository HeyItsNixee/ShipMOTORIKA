using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using ShipMotorika;
using static UnityEngine.Rendering.DebugUI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private SettingSlider settingSlider;
    public SettingSlider SettingSlider => settingSlider;
    [SerializeField] private string nameParameter;

    private float minRealValue = -40f;
    public float MinRealValue => minRealValue;
    private float maxRealValue = 0f;

    private void Start()
    {
        settingSlider.Slider.onValueChanged.AddListener(delegate { SetAudioVolume(); });
    }

    public void SetAudioVolume()
    {
        float value = 0f;
        if (settingSlider.Slider.value <= 0.05f)
            value = -80f;
        else
            value = (settingSlider.Slider.value * Mathf.Abs(minRealValue)) - Mathf.Abs(minRealValue);
        //(40 + x) / 40;  x = -40, -39, -38, ... , 0;

        settingSlider.UpdateFillImage(settingSlider.Slider.value);

        SettingsPanel_UI.Instance.Mixer.SetFloat(nameParameter, value);

        if (nameParameter == "SFX_Volume")
            PlayerSettingsHolder.Instance.settings.soundVolume = value;
        if (nameParameter == "Music_Volume")
            PlayerSettingsHolder.Instance.settings.musicVolume = value;
    }
}
