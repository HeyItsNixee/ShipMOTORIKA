using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ������� ����� ����� ���� � ��������� ������ ������ �������� ����������.
    /// </summary>
    public class FishSpawner : MonoBehaviour
    {
        /// <summary>
        /// ��� ���� ������: 1) �� ������ �����; 2) ������ ��� ����� ��������� ����; 3) ������������ ����������� ���������� fishingPoint; 4) �� ��������.
        /// </summary>
        public enum SpawnMode
        {
            Start,
            Single,
            ConstantAmount,
            Loop
        }

        [SerializeField] private SpawnMode _spawnMode;
        [SerializeField] private FishingPoint _fishingPlacePrefab;
        [SerializeField] private CircleArea _area;
        [SerializeField] private int _numSpawns;
        [SerializeField] private float _respawnTime;

        private FishingPoint _currentPoint = null;
        private float _timer = 0f;

        private void Start()
        {
            switch (_spawnMode)
            {
                case SpawnMode.Start:

                    SpawnFish();
                    break;

                case SpawnMode.ConstantAmount:

                    SpawnFish();
                    FishingPoint.OnFishPointDestroy += TryToCompleteSpawnedAmount;
                    break;
            }
        }

        private void Update()
        {
            switch (_spawnMode)
            {
                case SpawnMode.Single:

                    if (_currentPoint == null)
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

        private void OnDestroy()
        {
            if (_spawnMode == SpawnMode.ConstantAmount)
            {
                FishingPoint.OnFishPointDestroy -= TryToCompleteSpawnedAmount;
            }
        }

        /// <summary>
        /// ���������, ����� ������� ������ �� ���������� ���� � �����.
        /// </summary>
        /// <returns></returns>
        private bool AreaIsClean()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _area.Radius);

            if (hits.Length > 0)
            {
                int maxAttempts = 100; // ������������ ���������� ������� ��������. ����� ��� ����������� �������� ��������.
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
        /// ��������������� �����.
        /// </summary>
        private void SpawnFish()
        {
            for (int i = 0; i < _numSpawns; i++)
            {
                if (AreaIsClean())
                {
                    var fishingPoint = Instantiate(_fishingPlacePrefab);
                    fishingPoint.transform.position = _area.GetRandomInsideZone();
                    fishingPoint.transform.rotation = Quaternion.identity;

                    _currentPoint = fishingPoint; // Attention!
                }
            }
        }

        /// <summary>
        /// ���������, ���� ���������� FishingPoint, � ���� ������ ���������� �� ������, ��������� ���.
        /// </summary>
        private void TryToCompleteSpawnedAmount()
        {
            if (_spawnMode == SpawnMode.ConstantAmount)
            {
                int amount = FishingPoint.AllFishingPoints.Count;

                if (amount < _numSpawns)
                {
                    int defaultAmount = _numSpawns;
                    _numSpawns = _numSpawns - amount;
                    SpawnFish();
                    _numSpawns = defaultAmount;
                }
            }
        }
    }
}