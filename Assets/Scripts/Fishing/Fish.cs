using UnityEngine;

namespace ShipMotorika
{
    public class Fish : MonoBehaviour//, IInitializer
    {
        [SerializeField] private SpriteRenderer _sprite;
        public SpriteRenderer Sprite => _sprite;

        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private string _description;
        public string Description => _description;

        [SerializeField] private int _cost;
        public int Cost => _cost;

        [SerializeField] private int _weight;
        public int Weight => _weight;   

        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _name = asset.Name; 
            _description = asset.Description;
            _cost = asset.Cost;
            _weight = asset.Weight;
        }
    }
}