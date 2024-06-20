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
        /// Визуальная модель удочки
        /// </summary>
        [SerializeField] private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Скорость вращения удочки.
        /// </summary>
        [SerializeField] private float _rotationSpeed;

        /// <summary>
        /// Если значение "true", удочка будет отображаться только при рыбалке.
        /// </summary>
        [SerializeField] private bool _isOnlyOnFishingChallenge;

        private Quaternion _targetRotation;

        #region UnityEvents
        private void Start()
        {
            if (_isOnlyOnFishingChallenge)
            {
                _spriteRenderer.enabled = false;
            }
            else
            {
                _spriteRenderer.enabled = true;
            }
            
            FishingChallenge.Instance.OnEnable += TurnToTarget;
            FishingChallenge.Instance.OnDisable += SetDefaultRotation;
        }

        private void Update()
        {
            if (!_isOnlyOnFishingChallenge)
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
            FishingChallenge.Instance.OnEnable -= TurnToTarget;
            FishingChallenge.Instance.OnDisable -= SetDefaultRotation;
        }
        #endregion

        /// <summary>
        /// Поворачивает удочку в сторону цели.
        /// </summary>
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
        /// Возвращает удочку в исходное положение.
        /// </summary>
        private void SetDefaultRotation()
        {
            _spriteRenderer.enabled = false;

            transform.rotation = Quaternion.Euler(_ship.transform.localEulerAngles);
        }

        /// <summary>
        /// Переключает режим использования: всегда показывать / только при рыбалке.
        /// </summary>
        /// <param name="value"></param>
        public void SetUpdateModeActive(bool value)
        {
            _spriteRenderer.enabled = value;
            _isOnlyOnFishingChallenge = value;
        }
    }
}