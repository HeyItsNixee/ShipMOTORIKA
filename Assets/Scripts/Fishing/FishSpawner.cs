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
        [SerializeField] private FishingPoint _fishingPlacePrefab;
        [SerializeField] private CircleArea _area;
        [SerializeField] private int _numSpawns;
        [SerializeField] private float _respawnTime;

        private FishingPoint _currentPlace = null;
        private float _timer = 0f;

        private void Start()
        {
            switch (_spawnMode)
            {
                case SpawnMode.Start:

                    SpawnFish();
                    break;
            }
        }

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
        /// Проверяет, чтобы объекты спавна не появлялись друг в друге.
        /// </summary>
        /// <returns></returns>
        private bool AreaIsClean()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _area.Radius);

            if (hits.Length > 0)
            {
                int maxAttempts = 100; // Максимальное количество попыток итераций. Нужно для ограничений рпасхода ресурсов.
                for (int i = 0; i < maxAttempts; i++)
                {
                    float x = Random.Range(-_area.Radius, _area.Radius);
                    float y = Random.Range(-_area.Radius, _area.Radius);
                    Vector3 spawnPosition = transform.position + new Vector3(x, y, 0);

                    bool isOverlapping = false;
                    foreach (Collider2D hit in hits)
                    {
                        if (hit.bounds.Contains(spawnPosition))
                        {
                            isOverlapping = true;
                            break;
                        }
                    }

                    if (!isOverlapping)
                    {
                        return true;
                    }
                }
                return false;
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