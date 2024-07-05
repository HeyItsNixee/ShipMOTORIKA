using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public static class RestorePointData
    {
        /// <summary>
        /// Имя файла, отвечающего за сохранение точки возрождения.
        /// </summary>
        private const string Filename = "RestorePoint.dat";

        private static TransformData _transformData;
        public static TransformData Transform => _transformData;

        public static bool HasSave()
        {
            return FileHandler.HasFile($"{SceneManager.GetActiveScene().name}_{Filename}");
        }

        public static void Load()
        {
            Saver<TransformData>.TryLoad($"{SceneManager.GetActiveScene().name}_{Filename}", ref _transformData);
        }

        public static void Save()
        {
            var restore = Player.Instance.ShipRestorer.RestorePoint.RestorePosition;

            _transformData = new TransformData();

            _transformData.Position = restore.position;
            _transformData.Rotation = restore.rotation;
            _transformData.Scale = restore.localScale;

            Saver<TransformData>.Save($"{SceneManager.GetActiveScene().name}_{Filename}", _transformData);
        }

        public static void DeleteSceneData(string sceneName)
        {
            string filePath = $"{sceneName}_{Filename}";

            if (FileHandler.HasFile(filePath))
            {
                FileHandler.Reset(filePath);
            }
        }
    }
}