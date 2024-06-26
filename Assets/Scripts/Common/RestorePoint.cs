using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет появляться уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour
    {
        [SerializeField] private Transform _position;
        public Transform Position => _position;

        public void SetPlayerRestorePosition(Transform position)
        {
            _position = position;
        }
    }
}