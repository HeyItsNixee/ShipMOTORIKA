using UnityEngine.SceneManagement;
using UnityEngine;

namespace ShipMotorika
{
    public class DebugRestartScene : MonoBehaviour
    {
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneDataHandler.Instance?.Save();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReloadLevel();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneDataHandler.Instance?.DeleteCurrentSceneData();

                ReloadLevel();
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneDataHandler.Instance?.ResetAllSceneData();

                ReloadLevel();
            }
        }

        private void ReloadLevel()
        {
            string scenename = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(scenename);
        }
    }
}