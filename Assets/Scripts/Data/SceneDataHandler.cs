using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public class SceneDataHandler : SingletonBase<SceneDataHandler>, ILoader, ISaver
    {
        private const string Filename = "Scene.dat";

        private string Scenename;

        private SceneData _sceneData;
        public SceneData SceneData => _sceneData;
        
        private new void Awake()
        {
            base.Awake();

            PersistentDataHandler.Loaders.Add(this);
            PersistentDataHandler.Savers.Add(this);

            Scenename = SceneManager.GetActiveScene().name;
        }

        public bool HasSave()
        {
            return FileHandler.HasFile($"{Scenename}_{Filename}");
        }

        public void Load()
        {            
            Saver<SceneData>.TryLoad($"{Scenename}_{Filename}", ref _sceneData);
        }

        public void Save()
        {
            Saver<SceneData>.Save($"{Scenename}_{Filename}", _sceneData);
        }

        public void Delete()
        {
            string filePath = $"{Scenename}_{Filename}";

            if (FileHandler.HasFile(filePath))
            {
                FileHandler.Reset(filePath);
            }
        }
    }
}