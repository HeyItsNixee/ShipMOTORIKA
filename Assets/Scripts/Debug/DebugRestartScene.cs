using UnityEngine.SceneManagement;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Перезагружает активную сцену и удаляет все сохраненные данные на этой сцене.
    /// </summary>
    public class DebugRestartScene : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResetLevel();
            }
        }

        private void ResetLevel()
        {
            string scenename = SceneManager.GetActiveScene().name;

            PlayerData.DeleteSceneData(scenename);
            SceneManager.LoadScene(scenename);
        }
    }
}