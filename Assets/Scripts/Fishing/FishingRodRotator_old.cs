 using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Второй вариант скрипта. Позже объединю функционал в один класс.
    /// </summary>
    public class FishingRodRotator_old : MonoBehaviour
    {
        [SerializeField] private Transform _ship;      
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _rotationSpeed;
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

            var challenge = FishingChallenge.Instance;
            if (challenge)
            {
                challenge.OnEnable += TurnToTarget;
                challenge.OnDisable += SetDefaultRotation;
            }
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
            var challenge = FishingChallenge.Instance;        
            if (challenge)
            {
                challenge.OnEnable -= TurnToTarget;
                challenge.OnDisable -= SetDefaultRotation;
            }
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

        private void SetDefaultRotation()
        {
            _spriteRenderer.enabled = false;

            transform.rotation = Quaternion.Euler(_ship.transform.localEulerAngles);
        }

        public void SetUpdateModeActive(bool value)
        {
            _spriteRenderer.enabled = value;
            _isOnlyOnFishingChallenge = value;
        }
    }
}