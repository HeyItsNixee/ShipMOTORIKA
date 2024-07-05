using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    /// Сохраняет данные о характеристиках удочки игрока.
    /// </summary>
    public static class FishingRodData
    {
        /// <summary>
        /// Имя файла, отвечающего за сохранение характеристик удочки.
        /// </summary>
        private const string Filename = "FishingRod.dat";

        private static FishingRodAsset _savedAsset;
        public static FishingRodAsset Asset => _savedAsset;

        public static bool HasSave()
        {
            return FileHandler.HasFile($"{SceneManager.GetActiveScene().name}_{Filename}");
        }

        public static void Load()
        {
            Saver<FishingRodAsset>.TryLoad($"{SceneManager.GetActiveScene().name}_{Filename}", ref _savedAsset);
        }

        public static void Save()
        {
            var fishingRod = Player.Instance.FishingRod;

            _savedAsset = fishingRod.Asset;

            Saver<FishingRodAsset>.Save($"{SceneManager.GetActiveScene().name}_{Filename}", _savedAsset);
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