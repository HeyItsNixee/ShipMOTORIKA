using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет возродится уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour, ILoader, ISaver
    {
        [SerializeField] private Transform _restoreTransform;
        public Transform RestoreTransform => _restoreTransform;

        #region UnityEvents
        private void Awake()
        {
            SceneDataHandler.Loaders.Add(this);
            SceneDataHandler.Savers.Add(this);
        }
        #endregion

        public void SetRestoreTransform(Transform transform)
        {
            _restoreTransform = transform;
        }

        public void Load()
        {
            var restore = Player.Instance.ShipRestorer.RestorePoint.RestoreTransform;
            var data = SceneDataHandler.Data;

            restore.position = data.RestorePosition;
            restore.rotation = data.RestoreRotation;
            restore.localScale = data.RestoreScale;
        }

        public void Save()
        {
            var restore = Player.Instance.ShipRestorer.RestorePoint.RestoreTransform;
            var data = SceneDataHandler.Data;

            data.RestorePosition = restore.position;
            data.RestoreRotation = restore.rotation;
            data.RestoreScale = restore.localScale;
        }
    }
}