using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    ///  Хранит данные о местоположении корабля игрока.
    /// </summary>
    public static class ShipPositionData
    {
        /// <summary>
        /// Имя файла, отвечающего за сохранение позиции корабля.
        /// </summary>
        private const string Filename = "ShipPosition.dat";

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
            var ship = Player.Instance.Ship.gameObject.transform;

            _transformData = new TransformData();

            _transformData.Position = ship.position;
            _transformData.Rotation = ship.rotation;
            _transformData.Scale = ship.localScale;

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