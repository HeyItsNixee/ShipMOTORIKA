using UnityEngine;
using UnityEngine.UI;

namespace ShipMotorika
{
    /// <summary>
    /// Показывает подробную информацию о пойманной рыбе.
    /// </summary>
    public class FishCard : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _name;
        [SerializeField] private Text _description;
        [SerializeField] private Text _weight;
        [SerializeField] private Text _cost;

        public void Initialize()
        {
            var fish = Player.Instance.FishingRod.CaughtFish;      
            var sprite = fish.Sprite;

            _image.sprite = sprite.sprite;
            _name.text = fish.Name;
            _description.text = fish.Description;
            _weight.text = fish.Weight.ToString();
            _cost.text = fish.Cost.ToString();
        }
    }
}