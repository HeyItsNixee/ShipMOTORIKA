using UnityEngine;

namespace ShipMotorica
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private CircleArea _area;

        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _area.TrySetRadius(asset.Radius);
        }
    }
}