using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ShipMotorika;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Start()
    {
        if (SceneDataHandler.Instance.HasSave())
            continueButton.interactable = true;
        else
            continueButton.interactable = false;

    }

    public void Continue()
    {
        SceneManager.LoadScene("World");
    }

    public void NewGame()
    {
        SceneDataHandler.Instance.ResetAllSceneData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
