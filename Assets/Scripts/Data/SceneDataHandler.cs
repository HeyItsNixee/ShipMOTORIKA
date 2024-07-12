using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public class SceneDataHandler : SingletonBase<SceneDataHandler>, ILoader, ISaver
    {
        private const string Filename = "Scene.json";

        private string _currentSceneName;

        private static SceneData _sceneData = new();
        public static SceneData Data => _sceneData;

        private readonly HashSet<ILoader> iLoadDataObjects = new();

        private readonly HashSet<ISaver> iSaveDataObjects = new();

        private new void Awake()
        {
            base.Awake();

            _currentSceneName = SceneManager.GetActiveScene().name;
        }

        private void Start()
        {
            Load();
        }

        public void AddToSceneObjList(object obj)
        {
            if (obj is ILoader loader)
            {
                iLoadDataObjects.Add(loader);
            }
            if (obj is ISaver saver)
            {
                iSaveDataObjects.Add(saver);
            }
        }

        public void RemoveFromSceneObjList(object obj)
        {
            if (obj is ILoader loader)
            {
                iLoadDataObjects.Remove(loader);
            }
            if (obj is ISaver saver)
            {
                iSaveDataObjects.Remove(saver);
            }
        }

        public bool HasSave()
        {
            return FileHandler.HasFile($"{_currentSceneName}_{Filename}");
        }

        public void Load()
        {
            Saver<SceneData>.TryLoad($"{_currentSceneName}_{Filename}", ref _sceneData);

            if (HasSave())
            {
                foreach (var loader in iLoadDataObjects)
                {
                    loader.Load();
                }

                print("SceneData LOADED");
            }
            else
            {
                print("SceneData EMPTY");
            }
        }

        public void Save()
        {
            foreach (var saver in iSaveDataObjects)
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
    }
}