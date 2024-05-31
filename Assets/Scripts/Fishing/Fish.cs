using UnityEngine;

namespace ShipMotorika
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private CircleArea _area;
        [SerializeField] private FishingChallenge _fishingChallenge;

        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _area.TrySetRadius(asset.Radius);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out var player) && player.FishingRod != null)
            {
                _fishingChallenge = Instantiate(_fishingChallenge, transform.position, Quaternion.identity);
                _fishingChallenge.gameObject.SetActive(true);
                _fishingChallenge.OnDestroy += DestroyItself;
            }
        }

        private void DestroyItself()
        {
            _fishingChallenge.OnDestroy -= DestroyItself;
            Destroy(gameObject);
        }
    }
}