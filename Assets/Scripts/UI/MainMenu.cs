using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;
    //[SerializeField] private Button exitButton;

    private void Start()
    {
        Debug.Log("Save system TBD, disabling continue button");
        continueButton.interactable = false;
    }

    public void Continue()
    {
        Debug.Log("Continue feature wasn't implemented yet!");
    }

    public void NewGame()
    {
        //Clear save file
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
