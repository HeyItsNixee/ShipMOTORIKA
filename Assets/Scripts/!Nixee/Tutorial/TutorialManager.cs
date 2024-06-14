using ShipMotorika;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : Singleton<TutorialManager>
{
    [SerializeField] private GameObject[] screens;

    private int currentIndex = 0;

    private void Start()
    {
        for (int i = 0; i < screens.Length; i++)
            screens[i].SetActive(false);

        screens[currentIndex].SetActive(true);
        PlayerController.Instance.DisableControl();
    }


    public void ShowNext()
    {
        currentIndex++;
        if (currentIndex >= screens.Length)
        {
            currentIndex = screens.Length - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        screens[currentIndex - 1].SetActive(false);
        screens[currentIndex].SetActive(true);
        PlayerController.Instance.DisableControl();
    }
}
