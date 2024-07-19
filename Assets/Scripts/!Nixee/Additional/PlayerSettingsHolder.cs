using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


namespace ShipMotorika {
    public class PlayerSettingsHolder : SingletonBase<PlayerSettingsHolder>, ISaver, ILoader
    {
        private static string Filename = "Settigns.json";
        [HideInInspector] public PlayerSettings settings;

        private void Start()
        {
            if (settings == null)
                settings = new PlayerSettings();

            Load();
            Application.targetFrameRate = 60;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode lsm)
        {
            UpdateSettingsInGame();
        }

        public void UpdateSettingsInGame()
        {
            if (PlayerController.Instance != null)
                PlayerController.Instance.SideButtonControlEnable(settings.sideControlButtonsEnabled);

            SettingsPanel_UI.Instance.UpdateSettings();
            SettingsPanel_UI.Instance.SetSlidersValue();
        }

        public void SetSideControlButtonsEnabled(bool value)
        {
            settings.sideControlButtonsEnabled = value;
            UpdateSettingsInGame();
        }

        public void Save()
        {
            string path = Application.persistentDataPath + Filename;
            var data = JsonUtility.ToJson(settings, true);
            File.WriteAllText(path, data);
        }

        public void Load()
        {
            string path = Application.persistentDataPath + Filename;
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                var savedData = JsonUtility.FromJson<PlayerSettings>(data);

                settings.sideControlButtonsEnabled = savedData.sideControlButtonsEnabled;
                settings.soundVolume = savedData.soundVolume;
                settings.musicVolume = savedData.musicVolume;
                settings.playerName = savedData.playerName;
                settings.avatarSpriteIndex = savedData.avatarSpriteIndex;
                UpdateSettingsInGame();
            }
            else
            {
                Debug.LogWarning("No savefile in " + path + " has found. Creating a new one");
                Save();
                return;
            }
        }
    }
}
