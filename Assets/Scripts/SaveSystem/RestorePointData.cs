using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public static class RestorePointData
    {
        /// <summary>
        /// Вспомогательный класс для сохранения позиции точки возрождения корабля.
        /// </summary>
        [Serializable]
        public sealed class SavedTransform
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale;
        }

        /// <summary>
        /// »м¤ файла, отвечающего за сохранение точки возрождения.
        /// </summary>
        private const string Filename = "RestorePoint.dat";

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
            var transform = Player.Instance.ShipRestorer.RestorePoint.RestorePosition;

            _savedTransform.Position = transform.position;
            _savedTransform.Rotation = transform.rotation;
            _savedTransform.Scale = transform.localScale;

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