using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ShipMotorika;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Start()
    {
        if (FileHandler.HasFile("World_Scene.json"))
            continueButton.interactable = true;
        else
            continueButton.interactable = false;

    }

    public void Continue()
    {
        SceneManager.LoadScene("World");
    }

    public void ExitGame()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
