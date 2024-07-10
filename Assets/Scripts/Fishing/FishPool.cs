using System.Linq;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Определяет, какая рыба будет ловиться определенной удочкой.
    /// </summary>
    public class FishPool : MonoBehaviour, IInitializer
    {
        [Header("Fish assets")]
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

        [Header("Artifact assets")]
        [Range(0, 100)]
        [SerializeField] private int _artifactChance;
        public int ArtifactChance => _artifactChance;

        [SerializeField] private FishAsset[] _artifactArray;
        public FishAsset[] ArtifactArray => _artifactArray;

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
            else if (fishingRod == _bronzeFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).ToArray();
            }
            else if (fishingRod == _silverFishingRod)
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).Concat(_silverArray).ToArray();
            }
            else
            {
                _currentArray = new FishAsset[_defaultArray.Length];
                _currentArray = _defaultArray.Concat(_bronzeArray).Concat(_silverArray).Concat(_goldArray).ToArray();
            }
        }
    }
}