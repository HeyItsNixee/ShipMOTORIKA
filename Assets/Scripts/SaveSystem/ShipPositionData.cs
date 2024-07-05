using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    ///  Хранит данные о местоположении корабля игрока.
    /// </summary>
    public class ShipPositionData
    {
        /// <summary>
        /// Вспомогательный класс для сохранения позиции корабля.
        /// </summary>
        [Serializable]
        public sealed class SavedTransform
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale;
        }

        /// <summary>
        /// Имя файла, отвечающего за сохранение позиции корабля.
        /// </summary>
        private const string Filename = "ShipPosition.dat";

        private static SavedTransform _savedTransform;
        public static SavedTransform Transform => _savedTransform;

        public static bool HasSave()
        {
            return FileHandler.HasFile($"{SceneManager.GetActiveScene().name}_{Filename}");
        }

        public static void Load()
        {
            Saver<SavedTransform>.TryLoad($"{SceneManager.GetActiveScene().name}_{Filename}", ref _savedTransform);
        }

        public static void Save()
        {
            var ship = Player.Instance.Ship.gameObject.transform;

            _savedTransform.Position = ship.position;
            _savedTransform.Rotation = ship.rotation;
            _savedTransform.Scale = ship.localScale;

            Saver<SavedTransform>.Save($"{SceneManager.GetActiveScene().name}_{Filename}", _savedTransform);
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