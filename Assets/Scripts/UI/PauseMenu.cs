using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //OnEnable

    public void ReturnToMainMenu()
    {
        Debug.Log("Save system TBD");
        SceneManager.LoadScene("MainMenu");
    }

}
