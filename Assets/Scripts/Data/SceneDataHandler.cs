using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public class SceneDataHandler : SingletonBase<SceneDataHandler>, ILoader, ISaver
    {
        private const string Filename = "Scene.json";

        private string _currentSceneName;

        private static SceneData _sceneData = new();
        public static SceneData Data => _sceneData;

        private static List<ILoader> _loaders = new();
        public static List<ILoader> Loaders => _loaders;

        private static List<ISaver> _savers = new();
        public static List<ISaver> Savers => _savers;

        private new void Awake()
        {
            base.Awake();

            _currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void Start()
        {
            Load();
        }

        public bool HasSceneSave()
        {
            return FileHandler.HasFile($"{_currentSceneName}_{Filename}");
        }

        public bool HasSave()
        {
            return FileHandler.HasFile("World_" + Filename);
        }

        public void Load()
        {
            Saver<SceneData>.TryLoad($"{_currentSceneName}_{Filename}", ref _sceneData);

            if (HasSceneSave())
            {
                foreach (var loader in _loaders)
                {
                    loader.Load();
                }

                print("SceneData LOADED");
            }
            else
            {
                Save();
                print("SceneData EMPTY");
            }
        }

        public void Save()
        {
            foreach (var saver in _savers)
            {
                saver.Save();
            }

            Saver<SceneData>.Save($"{_currentSceneName}_{Filename}", _sceneData);

            print("SceneData SAVED");
        }

        public void DeleteCurrentSceneData()
        {
            string filePath = $"{_currentSceneName}_{Filename}";

            if (FileHandler.HasFile(filePath))
            {
                FileHandler.Reset(filePath);
            }

            print("SceneData DELETED");
        }

        public void ResetAllSceneData()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);

                string filePath = $"{scene.name}_{Filename}";

                if (FileHandler.HasFile(filePath))
                {
                    FileHandler.Reset(filePath);
                }
            }

            print("All SceneData RESETED");
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}