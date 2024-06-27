using UnityEngine;
using UnityEngine.UI;

public class CastingAFishingRodSound : MonoBehaviour
{
    [Tooltip("������ ��������� ��� ���������������")]
    public AudioClip castingAFishingRod;

    [Tooltip("������ ��������� ��� ���������������")]
    public AudioClip pullTheFishingRod;

    [Tooltip("������������� ��� ��������������� ������")]
    public AudioSource audioSource;

    [Tooltip("������, ��� ������� �� ������� ����� ���������������� �����")]
    public Button playButton;

    private bool playFirstSound = true; // ���� ��� �����������, ����� ���� ��������������

    void Start()
    {
        // ���������, ��� ������ � ������������� ���������
        if (playButton != null && audioSource != null)
        {
            // ��������� ��������� �� ������
            playButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (playFirstSound)
        {
            // ������������� ������ ����
            audioSource.PlayOneShot(castingAFishingRod);
        }
        else
        {
            // ������������� ������ ����
            audioSource.PlayOneShot(pullTheFishingRod);
        }

        // ����������� ����
        playFirstSound = !playFirstSound;
    }
}
