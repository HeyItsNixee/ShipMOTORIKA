using ShipMotorika;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //OnEnable

    public void ReturnToMainMenu()
    {
        if (SceneDataHandler.Instance != null)
            SceneDataHandler.Instance.Save();

        if (PlayerSettingsHolder.Instance != null)
            PlayerSettingsHolder.Instance.Save();

        SceneManager.LoadScene("MainMenu");
    }

}
