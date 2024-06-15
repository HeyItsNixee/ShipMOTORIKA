using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Спавнит места ловли рыбы в случайных точках внутри заданной окружности.
    /// </summary>
    public class FishSpawner : Spawner
    {
        /// <summary>
        /// Если включено, поддерживает 
        /// </summary>
        [SerializeField] private bool _isConstantAmount;

        private new void Start()
        {
            base.Start();

            if (_isConstantAmount)
            {
                FishingPoint.OnFishPointDestroy += TryToCompleteSpawnedAmount;
            }
        }

        private void OnDestroy()
        {
            if (_isConstantAmount)
            {
                FishingPoint.OnFishPointDestroy -= TryToCompleteSpawnedAmount;
            }
        }

        /// <summary>
        /// Проверяет, если количество FishingPoint, и если меньше количества на старте, дополняет его.
        /// </summary>
        private void TryToCompleteSpawnedAmount()
        {
            if (_isConstantAmount)
            {
                int amount = FishingPoint.AllFishingPoints.Count;

                if (amount < _numSpawns)
                {
                    int defaultAmount = _numSpawns;
                    _numSpawns = _numSpawns - amount;
                    SpawnEntity();
                    _numSpawns = defaultAmount;

                    Player.Instance.FishingRod?.FindFishNearby(); // Attention!
                }
            }
        }
    }
}