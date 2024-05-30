using UnityEngine;

namespace ShipMotorica
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
                var challenge = Instantiate(_fishingChallenge, transform.position, Quaternion.identity);
                challenge.gameObject.SetActive(true);
     
                Destroy(gameObject);
            }
        }
    }
}