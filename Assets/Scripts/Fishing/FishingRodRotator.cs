using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Поворачивает удочку в сторону активного места рыбалки.
    /// </summary>
    public class FishingRodRotator : MonoBehaviour
    {
        [SerializeField] private Transform _ship;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _rotationSpeed;

        private Quaternion _targetRotation;
        private bool _isActive;

        #region UnityEvents
        private void Start()
        {
            _spriteRenderer.enabled = false;

            Player.Instance.FishingRod.OnFishingPlaceNearby += SetUpdateModeActive;
        }

        private void Update()
        {
            if (_isActive)
            {
                _spriteRenderer.enabled = true;

                var fishingPoint = Player.Instance.FishingRod.FishingPoint;

                if (fishingPoint)
                {
                    Vector3 direction = fishingPoint.transform.position - transform.position;
                    direction.Normalize();
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    _targetRotation = Quaternion.Euler(0f, 0f, angle - 90);
                }
                else
                {
                    _targetRotation = Quaternion.Euler(_ship.transform.localEulerAngles);
                }

                transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }

        private void OnDestroy()
        {
            Player.Instance.FishingRod.OnFishingPlaceNearby -= SetUpdateModeActive;
        }
        #endregion

        private void TurnToTarget()
        {
            _spriteRenderer.enabled = true;

            var fishingPoint = Player.Instance.FishingRod.FishingPoint;

            if (fishingPoint)
            {
                Vector3 direction = fishingPoint.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
            }
        }

        /// <summary>
        /// Переключает режим использования: всегда показывать / только при рыбалке.
        /// </summary>
        /// <param name="value"></param>
        private void SetUpdateModeActive(bool value)
        {
            TurnToTarget();

            _spriteRenderer.enabled = value;
            _isActive = value;
        }
    }
}