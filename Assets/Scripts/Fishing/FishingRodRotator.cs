using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Поворачивает удочку в сторону активного места рыбалки.
    /// </summary>
    public class FishingRodRotator : MonoBehaviour
    {
        /// <summary>
        /// Позиция корабля. Нужна для синхронизации положения удочки.
        /// </summary>
        [SerializeField] private Transform _ship;

        /// <summary>
        /// Скорость вращения удочки.
        /// </summary>
        [SerializeField] private float _rotationSpeed;

        private Quaternion _targetRotation;
        
        private void Update()
        {
            var fishingPoint = Player.Instance.FishingRod.FishingPoint;

            if (fishingPoint)
            {
                Vector3 direction = transform.position - fishingPoint.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                _targetRotation = Quaternion.Euler(0f, 0f, -Mathf.Abs(angle));
            }
            else
            {
                _targetRotation = Quaternion.Euler(_ship.transform.localEulerAngles);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}