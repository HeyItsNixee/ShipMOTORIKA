using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    /// Сохраняет данные о характеристиках корабля игрока.
    /// </summary>
    public static class ShipAssetData
    {
        /// <summary>
        /// Имя файла, отвечающего за сохранение характеристик корабля.
        /// </summary>
        private const string Filename = "ShipAsset.dat";

        private static ShipAsset _savedAsset;
        public static ShipAsset Asset => _savedAsset;

        public static bool HasSave()
        {
            return FileHandler.HasFile($"{SceneManager.GetActiveScene().name}_{Filename}");
        }

        public static void Load()
        {
            Saver<ShipAsset>.TryLoad($"{SceneManager.GetActiveScene().name}_{Filename}", ref _savedAsset);
        }

        public static void Save()
        {
            var ship = Player.Instance.Ship;

            _savedAsset = ship.Asset;

            Saver<ShipAsset>.Save($"{SceneManager.GetActiveScene().name}_{Filename}", _savedAsset);
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