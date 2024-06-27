using UnityEngine;

public class BoatEngineSound : MonoBehaviour
{
    [Tooltip("AudioSource компонента с звуком мотора")]
    public AudioSource engineAudioSource;

    [Tooltip("Rigidbody лодки")]
    public Rigidbody2D boatRigidbody;

    [Tooltip("Минимальная высота звука")]
    public float minPitch = 0.5f;

    [Tooltip("Максимальная высота звука")]
    public float maxPitch = 2.0f;

    [Tooltip("Максимальная скорость лодки")]
    public float maxSpeed = 20f;

    [Tooltip("Максимальная громкость звука мотора")]
    public float maxVolume = 1.0f;

    void Update()
    {
        // Проверяем, если аудио источник и rigidbody заданы
        if (engineAudioSource != null && boatRigidbody != null)
        {
            // Получаем текущую скорость лодки
            float speed = boatRigidbody.velocity.magnitude;

            // Нормализуем скорость лодки в диапазон от 0 до 1
            float normalizedSpeed = speed / maxSpeed;

            // Изменяем высоту звука в зависимости от нормализованной скорости
            engineAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);

            // Изменяем громкость звука в зависимости от нормализованной скорости
            engineAudioSource.volume = Mathf.Lerp(0.05f, maxVolume, normalizedSpeed);
        }
    }
}
