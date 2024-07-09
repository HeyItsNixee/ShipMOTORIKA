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
        /// Точка, в которой появится корабль.
        /// </summary>
        [SerializeField] private RestorePoint _restorePoint;
        public RestorePoint RestorePoint => _restorePoint;

        /// <summary>
        /// Процент от здоровья с которым возродится корабль игрока.
        /// </summary>
        [Range(0, 1)]
        [SerializeField] private float _restoredHealthPercentage;

        public event Action OnShipRestored;

        public void RestoreShip()
        {
            var ship = Player.Instance.Ship;
            int health = Mathf.RoundToInt(ship.Health.MaxHealth * _restoredHealthPercentage);

            ship.Health.TryChangeHealthAmount(health);
            ship.FishContainer.ClearContainer();

            if (_restorePoint != null)
            {
                var position = _restorePoint.RestoreTransform.position;
                var rotation = _restorePoint.RestoreTransform.rotation;

                ship.gameObject.transform.position = position;
                ship.gameObject.transform.rotation = rotation;
            }

            OnShipRestored?.Invoke();
        }
    }
}