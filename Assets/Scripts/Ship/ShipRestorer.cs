using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Восстанавливает корабль игрока после его уничтожения.
    /// </summary>
    public class ShipRestorer : MonoBehaviour
    {
        /// <summary>
        /// Вспомогательный класс для сохранения позиции корабля.
        /// </summary>
        [Serializable]
        private sealed class SavedPosition
        {
            public Vector3 Position;
            public Quaternion Rotation;
        }

        /// <summary>
        /// Имя файла, отвечающего за сохранение позиции корабля.
        /// </summary>
        //private const string Filename = "ShipPosition.dat"; // Attention!

        /// <summary>
        /// Точка, в которой появится корабль.
        /// </summary>
        [SerializeField] private RestorePoint _restorePoint;
        public RestorePoint RestorePoint => _restorePoint;

        /// <summary>
        /// Процент от здоровья с которым возродится корабль игрока.
        /// </summary>
        [Range(0, 1)]
        [SerializeField] private float _restoredHealthPercentage;

        private SavedPosition _savedPosition;

        public event Action OnShipRestored;

        #region UnityEvents

        private void Start()
        {
            if (FileHandler.HasFile($"{UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}_ShipPosition.dat"))
            {
                LoadShipPosition();
                ReplaceShip();
            }

            SaveShipPosition();
        }

        private void OnApplicationQuit()
        {
            SaveShipPosition();
        }
        #endregion

        private void ReplaceShip()
        {
            var ship = Player.Instance.Ship.gameObject.transform;

            ship.position = _savedPosition.Position;
            ship.rotation = _savedPosition.Rotation;
        }

        private void LoadShipPosition()
        {
            Saver<SavedPosition>.TryLoad($"{UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}_ShipPosition.dat", ref _savedPosition);
        }

        public void SaveShipPosition()
        {
            var ship = Player.Instance.Ship.gameObject.transform;
            
            _savedPosition.Position = ship.position;
            _savedPosition.Rotation = ship.rotation;

            Saver<SavedPosition>.Save($"{UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}_ShipPosition.dat", _savedPosition);
        }

        public void RestoreShip()
        {
            var ship = Player.Instance.Ship;
            int health = Mathf.RoundToInt(ship.Health.MaxHealth * _restoredHealthPercentage);

            ship.Health.TryChangeHealthAmount(health);
            ship.FishContainer.ClearContainer();

            if (_restorePoint != null)
            {
                var position = _restorePoint.Transform.position;
                var rotation = _restorePoint.Transform.rotation;

                ship.gameObject.transform.position = position;
                ship.gameObject.transform.rotation = rotation;

                SaveShipPosition();
            }

            OnShipRestored?.Invoke();
        }
    }
}