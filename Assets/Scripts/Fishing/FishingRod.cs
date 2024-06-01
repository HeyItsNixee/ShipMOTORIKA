using UnityEngine;

namespace ShipMotorika
{
    public class FishingRod : MonoBehaviour
    {
        [SerializeField] private FishingRodAsset _asset;
          
        private float _radius;
        private float _speed;

        private void Start()
        {
            Initialize(_asset);
        }

        public void Initialize(FishingRodAsset asset)
        {
            _speed = asset.Speed;
            _radius = asset.Radius;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}