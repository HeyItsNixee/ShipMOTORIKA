using ShipMotorika;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingsPanel_UI : Singleton<SettingsPanel_UI>
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string SFXParam;
    [SerializeField] private string MusicParam;
    [SerializeField] private GameObject panel;
    public AudioMixer Mixer => audioMixer;

    [SerializeField] private AudioSetting SFX_Slider;
    [SerializeField] private AudioSetting Music_Slider;


    public void UpdateSettings()
    {
        audioMixer.SetFloat(SFXParam, PlayerSettingsHolder.Instance.settings.soundVolume);
        audioMixer.SetFloat(MusicParam, PlayerSettingsHolder.Instance.settings.musicVolume);
    }

    public void SetSlidersValue()
    {
        SFX_Slider.SettingSlider.Slider.value = (PlayerSettingsHolder.Instance.settings.soundVolume + Mathf.Abs(SFX_Slider.MinRealValue)) / Mathf.Abs(SFX_Slider.MinRealValue);
        SFX_Slider.SettingSlider.UpdateFillImage(SFX_Slider.SettingSlider.Slider.value);
        Music_Slider.SettingSlider.Slider.value = (PlayerSettingsHolder.Instance.settings.musicVolume + Mathf.Abs(Music_Slider.MinRealValue)) / Mathf.Abs(Music_Slider.MinRealValue);
        Music_Slider.SettingSlider.UpdateFillImage(Music_Slider.SettingSlider.Slider.value);
    }

    public void Close()
    {
        PlayerSettingsHolder.Instance.Save();
        panel.SetActive(false);
    }
}
