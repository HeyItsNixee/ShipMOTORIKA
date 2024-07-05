using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет появляться уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour
    {
        [SerializeField] private Transform _restorePosition;
        public Transform RestorePosition => _restorePosition;

        #region UnityEvents
        private void Awake()
        {
            RestorePointData.Load();
        }

        private void Start()
        {
            if (RestorePointData.HasSave())
            {
                ReplacePoint();
                RestorePointData.Save();
            }
        }

        private void OnApplicationQuit()
        {
            RestorePointData.Save();
        }
        #endregion

        private void ReplacePoint()
        {
            var data = RestorePointData.Transform;

            _restorePosition.position = data.Position;
            _restorePosition.rotation = data.Rotation;
            _restorePosition.localScale = data.Scale;
        }

        public void SetRestorePosition(Transform transform)
        {
            _restorePosition = transform;

            RestorePointData.Save();
        }
    }
}