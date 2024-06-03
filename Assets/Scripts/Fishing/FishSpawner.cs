using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Спавнит места ловли рыбы в случайных точках внутри заданной окружности.
    /// </summary>
    public class FishSpawner : MonoBehaviour
    {
        /// <summary>
        /// Три типа спавна: 1) На старте сцены; 2) Каждый раз после собранной рыбы; 3) по кулдауну.
        /// </summary>
        
        public enum SpawnMode
        {
            Start,
            Single,
            Loop
        }

        [SerializeField] private SpawnMode _spawnMode;
        [SerializeField] private FishingPlace _fishingPlacePrefab;
        [SerializeField] private CircleArea _area;      
        [SerializeField] private int _numSpawns;
        [SerializeField] private float _respawnTime;

        private FishingPlace _currentPlace = null;   
        private float _timer = 0f;

        private void Update()
        {
            switch (_spawnMode)
            {
                case SpawnMode.Single:

                    if (_currentPlace == null)
                    {
                        SpawnFish();
                    }
                    break;

                case SpawnMode.Loop:

                    _timer += Time.deltaTime;

                    if (_timer >= _respawnTime)
                    {
                        SpawnFish();
                        _timer = 0f;
                    }
                    break;
            }
        }
    
        /// <summary>
        /// Проверяет, есть ли в пределах заданной области корабль игрока.
        /// </summary>
        /// <returns></returns>
        private bool AreaIsClean()
        {
            if (Player.Instance != null)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _area.Radius);

                if (hits.Length > 0)
                {
                    foreach (Collider2D hit in hits)
                    {
                        if (hit.transform.root == Player.Instance.transform)
                        {
                            return false;
                        }
                            
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Непосредственно спавн.
        /// </summary>
        private void SpawnFish()
        {
            for (int i = 0; i < _numSpawns; i++)
            {
                if (AreaIsClean())
                {
                    var fishingPlace = Instantiate(_fishingPlacePrefab);
                    fishingPlace.transform.position = _area.GetRandomInsideZone();
                    fishingPlace.transform.rotation = Quaternion.identity;

                    _currentPlace = fishingPlace; // Attention!
                }
            }
        }
    }
}