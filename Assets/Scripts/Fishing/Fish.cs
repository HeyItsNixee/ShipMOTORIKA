using UnityEngine;

namespace ShipMotorika
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        private int _cost;
        public int Cost => _cost;

        private int _weight;
        public int Weight => _weight;   

        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _cost = asset.Cost;
            _weight = asset.Weight;
        }
    }
}