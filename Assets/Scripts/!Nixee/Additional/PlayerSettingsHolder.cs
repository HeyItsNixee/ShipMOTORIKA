using UnityEngine;
using UnityEngine.SceneManagement;


namespace ShipMotorika {
    public class PlayerSettingsHolder : SingletonBase<PlayerSettingsHolder>
    {
        public bool sideControlButtonsEnabled;
        private int soundVolume;
        private int musicVolume;

        private void Start()
        {
            UpdateSettingsInGame();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode lsm)
        {
            UpdateSettingsInGame();
        }

        public void UpdateSettingsInGame()
        {
            if (PlayerController.Instance == null)
                return;

            PlayerController.Instance.SideButtonControlEnable(sideControlButtonsEnabled);
            //sound and music volume
        }

        public void SetSideControlButtonsEnabled(bool value)
        {
            sideControlButtonsEnabled = value;
            UpdateSettingsInGame();
        }
    }
}
