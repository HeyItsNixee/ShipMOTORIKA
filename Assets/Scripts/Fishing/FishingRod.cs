using UnityEngine;

namespace ShipMotorika
{
    public class FishingRod : MonoBehaviour
    {
        [SerializeField] private FishingRodAsset _asset;
        [SerializeField] private CircleCollider2D _circleCollider;
        [SerializeField] private FishingChallenge _fishingChallenge;

        private Fish _fish;

        private float _radius;
        public float Radius => _radius;

        private float _speed;
        public float Speed => _speed;

        private float _cost;
        public float Cost => _cost;

        private void Start()
        {
            Initialize(_asset);
        }

        public void Initialize(FishingRodAsset asset)
        {
            _speed = asset.Speed;
            _radius = asset.Radius;
            _cost = asset.Cost;

            _circleCollider.radius = _radius;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Fish>(out var fish))
            {
                _fish = fish;

                _fishingChallenge.gameObject.transform.position = _fish.gameObject.transform.position;
                _fishingChallenge.Activate();
                _fishingChallenge.OnDisable += DestroyFishGameObject;
            }
        }

        private void DestroyFishGameObject()
        {
            Destroy(_fish.gameObject);
            _fishingChallenge.OnDisable -= DestroyFishGameObject;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}