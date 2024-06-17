using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Continue()
    {
        Debug.Log("Continue feature wasn't implemented yet!");
    }

    public void NewGame()
    {
        //Clear save file
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        Debug.Log("Settings feature wasn't implemented yet!");
    }

    public void ExitGame()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
