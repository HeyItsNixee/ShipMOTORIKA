using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Точка, в которой будет появляться уничтоженный корабль игрока.
    /// </summary>
    public class RestorePoint : MonoBehaviour, ILoader, ISaver
    {
        [SerializeField] private Transform _restoreTransform;
        public Transform RestoreTransform => _restoreTransform;

        #region UnityEvents
        private void Awake()
        {
            PersistentDataHandler.Loaders.Add(this);
            PersistentDataHandler.Savers.Add(this);
        }

        private void Start()
        {
            if (SceneDataHandler.Instance.HasSave()) // Attention!
            {
                ReplacePoint();
            }
        }
        #endregion

        private void ReplacePoint()
        {
            var data = SceneDataHandler.Instance.SceneData.RestorePointPosition; // Attention!

            _restoreTransform.position = data.Position;
            _restoreTransform.rotation = data.Rotation;
            _restoreTransform.localScale = data.Scale;
        }

        public void SetRestoreTransform(Transform transform)
        {
            _restoreTransform = transform;

            Save(); // Attention!
        }

        public void Load()
        {

        }

        public void Save()
        {

        }
    }
}