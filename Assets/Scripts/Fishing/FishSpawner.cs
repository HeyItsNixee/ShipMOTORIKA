using UnityEngine;

namespace ShipMotorica
{
    public class FishSpawner : MonoBehaviour
    {
        public enum SpawnMode
        {
            Single,
            Loop
        }

        [SerializeField] private FishAsset[] _fishAssets;
        [SerializeField] private Fish _fishPrefab;
        [SerializeField] private CircleArea _area;
        [SerializeField] private SpawnMode _spawnMode;
        [SerializeField] private int _numSpawns;
        [SerializeField] private float _respawnTime;

        private Fish _currentFish = null;   
        private float _timer = 0f;

        private void Update()
        {
            _timer += Time.deltaTime;        

            if (_spawnMode == SpawnMode.Loop && _timer >= _respawnTime)
            {
                SpawnFish();

                _timer = 0f;
            }

            if (_spawnMode == SpawnMode.Single && _currentFish == null)
            {
                SpawnFish();
            }
        }
    
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
                            return false;
                    }
                }
            }

            return true;
        }

        private void SpawnFish()
        {
            for (int i = 0; i < _numSpawns; i++)
            {
                if (AreaIsClean())
                {
                    int index = Random.Range(0, _fishAssets.Length);

                    var fish = Instantiate(_fishPrefab);
                    fish.transform.position = _area.GetRandomInsideZone();
                    fish.transform.rotation = Quaternion.identity;
                    fish.Initialize(_fishAssets[index]);

                    _currentFish = fish; // Attention!
                }
            }
        }
    }
}