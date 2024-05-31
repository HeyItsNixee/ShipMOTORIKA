using UnityEngine;

namespace ShipMotorika
{
    public class FishingRod : MonoBehaviour
    {
        [SerializeField] private FishingRodAsset _asset;
        [SerializeField] private float _speed; 

        private void Initialize()
        {
            _speed = _asset.Speed;
        }
    }
}