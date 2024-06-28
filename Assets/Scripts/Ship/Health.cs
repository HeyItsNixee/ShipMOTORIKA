using UnityEngine;
using System;

namespace ShipMotorika
{
    /// <summary>
    /// Здоровье корабля.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// Максимально допустимое значение здоровья корабля.
        /// </summary>
        [SerializeField] private int _maxHealth;
        public int MaxHealth => _maxHealth;

        /// <summary>
        /// Текущее значение здоровья корабля.
        /// </summary>
        [SerializeField] private int _currentHealth;
        public int CurrentHealth => _currentHealth;

        [Header("Collisions")]

        /// <summary>
        /// Минимальный обязательный урон при столкновениях.
        /// </summary>
        [SerializeField] private int _damageConstant;
        public int DamageConstant => _damageConstant;

        /// <summary>
        /// Множитель урона при столкновениях.
        /// </summary>
        [SerializeField] private float _damageMultiplier;
        public float DamageMultiplier => _damageMultiplier;

        /// <summary>
        /// Неуязвимость к урону.
        /// </summary>
        [SerializeField] private bool _isIndestructible;     

        public event Action OnHealthChanged;
        public event Action OnDeath;

        #region UnityEvents
        private void Start()
        {
            RestoreHealth(); // Заменить на загрузку сохраненного показателя здоровья.
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isIndestructible)
            {
                float collisionSpeed = collision.relativeVelocity.magnitude;
                int damage = Mathf.RoundToInt(_damageConstant + collisionSpeed * _damageMultiplier);

                TryChangeHealthAmount(-Math.Abs(damage));
            }
        }
        #endregion

        public void TryChangeHealthAmount(int amount)
        {
            if (amount != 0)
            {
                _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);

                if (_currentHealth == 0)
                {
                    OnDeath?.Invoke();
                }
                else
                {
                    OnHealthChanged?.Invoke();
                }
            }
        }

        public void RestoreHealth()
        {
            _currentHealth = _maxHealth;

            OnHealthChanged?.Invoke();
        }

        public void SetMaxHealth(int health)
        {
            if (health > 0)
            {
                _maxHealth = health;
            }
        }
    }
}