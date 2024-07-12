using UnityEngine.SceneManagement;
using UnityEngine;

namespace ShipMotorika
{
    public class DebugRestartScene : MonoBehaviour
    {
        SceneDataHandler SceneDataHandler => SceneDataHandler.Instance;

        private void Start()
        {
            if (SceneDataHandler == null)
            {
                enabled = false;
                
                print("No SceneDataHandler.Instance on scene!");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneDataHandler.Save();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReloadLevel();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneDataHandler.DeleteCurrentSceneData();

                ReloadLevel();
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneDataHandler.ResetAllSceneData();

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