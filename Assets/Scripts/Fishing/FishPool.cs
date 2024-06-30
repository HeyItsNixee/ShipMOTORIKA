using System.Linq;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Определяет какая рыба будет ловиться определенной удочкой.
    /// </summary>
    public class FishPool : MonoBehaviour
    {
        [Header("Useful fish")]
        [SerializeField] private FishingRodAsset _defaultFishingRod;
        [SerializeField] private FishAsset[] _defaultArray;      
        [Space]
        [SerializeField] private FishingRodAsset _bronzeFishingRod;
        [SerializeField] private FishAsset[] _bronzeArray;        
        [Space]
        [SerializeField] private FishingRodAsset _silverFishingRod;
        [SerializeField] private FishAsset[] _silverArray;      
        [Space]
        [SerializeField] private FishingRodAsset _goldFishingRod;
        [SerializeField] private FishAsset[] _goldArray;

        [Header("Garbage fish")]
        [SerializeField] private FishAsset[] _garbageArray;
        public FishAsset[] GarbageArray => _garbageArray;

        private FishAsset[] _currentArray;
        public FishAsset[] CurrentArray => _currentArray;

        public void Initialize()
        {
            var fishingRod = Player.Instance.FishingRod.Asset;
            
            if (fishingRod == _defaultFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];       
                _currentArray = _defaultArray;
            }

            if (fishingRod == _bronzeFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).ToArray();
            }

            if (fishingRod == _silverFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).Concat(_silverArray).ToArray();
            }

            if (fishingRod == _goldFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).Concat(_silverArray).Concat(_goldArray).ToArray();
            }
        }
    }
}