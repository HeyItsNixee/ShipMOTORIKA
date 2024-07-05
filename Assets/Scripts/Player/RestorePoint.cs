using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет появляться уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour
    {
        [SerializeField] private Transform _restoreTransform;
        public Transform RestoreTransform => _restoreTransform;

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

            _restoreTransform.position = data.Position;
            _restoreTransform.rotation = data.Rotation;
            _restoreTransform.localScale = data.Scale;
        }

        public void SetRestoreTransform(Transform transform)
        {
            _restoreTransform = transform;

            RestorePointData.Save();
        }
    }
}