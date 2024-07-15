using UnityEngine;

public class BoatEngineSound : MonoBehaviour
{
    [Tooltip("AudioSource ���������� � ������ ������")]
    public AudioSource engineAudioSource;

    [Tooltip("Rigidbody �����")]
    public Rigidbody2D boatRigidbody;

    [Tooltip("����������� ������ �����")]
    public float minPitch = 0.5f;

    [Tooltip("������������ ������ �����")]
    public float maxPitch = 2.0f;

    [Tooltip("������������ �������� �����")]
    public float maxSpeed = 20f;

    [Tooltip("������������ ��������� ����� ������")]
    public float maxVolume = 1.0f;

    void Update()
    {
        // ���������, ���� ����� �������� � rigidbody ������
        if (engineAudioSource != null && boatRigidbody != null)
        {
            // �������� ������� �������� �����
            float speed = boatRigidbody.velocity.magnitude;

            // ����������� �������� ����� � �������� �� 0 �� 1
            float normalizedSpeed = speed / maxSpeed;

            // �������� ������ ����� � ����������� �� ��������������� ��������
            engineAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);

            // �������� ��������� ����� � ����������� �� ��������������� ��������
            engineAudioSource.volume = Mathf.Lerp(0.05f, maxVolume, normalizedSpeed);
        }
    }
}
