using UnityEngine;

namespace ShipMotorika
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _speed;

        private void Update()
        {
            _targetTransform.Rotate(_speed * Time.deltaTime);
        }
    }
}