using UnityEngine;
using UnityEngine.UI;

public class CastingAFishingRodSound : MonoBehaviour
{
    [Tooltip("Первый аудиоклип для воспроизведения")]
    public AudioClip castingAFishingRod;

    [Tooltip("Второй аудиоклип для воспроизведения")]
    public AudioClip pullTheFishingRod;

    [Tooltip("Аудиоисточник для воспроизведения звуков")]
    public AudioSource audioSource;

    [Tooltip("Кнопка, при нажатии на которую будут воспроизводиться звуки")]
    public Button playButton;

    private bool playFirstSound = true; // Флаг для определения, какой звук воспроизводить

    void Start()
    {
        // Убедитесь, что кнопка и аудиоисточник назначены
        if (playButton != null && audioSource != null)
        {
            // Добавляем слушатель на кнопку
            playButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (playFirstSound)
        {
            // Воспроизводим первый звук
            audioSource.PlayOneShot(castingAFishingRod);
        }
        else
        {
            // Воспроизводим второй звук
            audioSource.PlayOneShot(pullTheFishingRod);
        }

        // Переключаем флаг
        playFirstSound = !playFirstSound;
    }
}
