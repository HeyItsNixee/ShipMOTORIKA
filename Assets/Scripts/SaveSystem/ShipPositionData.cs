using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    public class ShipPositionData
    {
        /// <summary>
        /// Вспомогательный класс для сохранения позиции корабля.
        /// </summary>
        [Serializable]
        public sealed class SavedPosition
        {
            public Vector3 Position;
            public Quaternion Rotation;
        }

        /// <summary>
        /// Имя файла, отвечающего за сохранение позиции корабля.
        /// </summary>
        private const string Filename = "ShipPosition.dat";

        private static SavedPosition _savedPosition;
        public static SavedPosition Saver => _savedPosition;

        public static bool HasSave()
        {
            return FileHandler.HasFile($"{SceneManager.GetActiveScene().name}_{Filename}");
        }

        public static void Load()
        {
            Saver<SavedPosition>.TryLoad($"{SceneManager.GetActiveScene().name}_{Filename}", ref _savedPosition);
        }

        public static void Save()
        {
            var ship = Player.Instance.Ship.gameObject.transform;

            _savedPosition.Position = ship.position;
            _savedPosition.Rotation = ship.rotation;

            Saver<SavedPosition>.Save($"{SceneManager.GetActiveScene().name}_{Filename}", _savedPosition);
        }
    }
}