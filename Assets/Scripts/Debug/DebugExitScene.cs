using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Имитирует выход со сцены.
    /// </summary>
    public class DebugExitScene : MonoBehaviour
    {
        private const string Filename = "debugTransform.dat";

        private Transform _transform;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SavePosition();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadPosition();
            }
        }

        private void SavePosition()
        {
            var ship = Player.Instance.Ship.gameObject;
            var transform = ship.transform;

            Player.Instance.ShipRestorer.RestorePoint.SetTransform(transform);

            _transform = transform;

            Saver<Transform>.Save(Filename, _transform);

            Debug.Log("Saved");
        }

        private void LoadPosition()
        {
            Saver<Transform>.TryLoad(Filename, ref _transform);

            //var ship = Player.Instance.Ship.gameObject;

            //ship.transform.position = _position;
  

            Debug.Log("Loaded");
        }

        private void Start()
        {
            LoadPosition();
            
            var ship = Player.Instance.Ship.gameObject;

            Vector3 position = _transform.position;
            Quaternion rotation = _transform.rotation;
            
            
            ship.transform.position = position;
            ship.transform.rotation = rotation;
        }
    }
}