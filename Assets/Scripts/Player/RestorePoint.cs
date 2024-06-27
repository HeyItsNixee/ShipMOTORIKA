using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет появляться уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;

        public void SetTransform(Transform transform)
        {
            _transform = transform;
        }
    }
}