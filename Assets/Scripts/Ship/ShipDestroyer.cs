using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Отключает изображение корабля, если его здоровье опустилось до 0.
    /// </summary>
    public class ShipDestroyer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        #region UnityEvents
        private void Start()
        {
            Player.Instance.Ship.Health.OnDeath += DisableSprite;
            Player.Instance.ShipRestorer.OnShipRestored += EnableSprite;
        }

        private void OnDestroy()
        {
            Player.Instance.Ship.Health.OnDeath -= DisableSprite;
            Player.Instance.ShipRestorer.OnShipRestored -= EnableSprite;
        }
        #endregion

        private void DisableSprite()
        {
            _sprite.enabled = false;
        }

        private void EnableSprite()
        {
            _sprite.enabled = true;
        }
    }
}