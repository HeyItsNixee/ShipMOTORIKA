using System;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ������ ������.
    /// </summary>
    public class FishingRod : MonoBehaviour
    {
        [SerializeField] private FishingRodAsset _asset;

        /// <summary>
        /// � ����������� �� ������� ����� ���������� ������� ���������� �� FishingPlace, �� ������� ����� ������ ����.
        /// </summary>
        [SerializeField] private CircleCollider2D _circleCollider;

        /// <summary>
        /// ��� �������� ������ ����� ��������/�������� ����� ���������.
        /// </summary>
        [SerializeField] private float _radius;
        public float Radius => _radius;

        /// <summary>
        /// �������� ����� ������. ��� ����, ��� ����� ����� ��������� ����-���� FishingChallenge.
        /// </summary>
        [SerializeField] private float _speed;
        public float Speed => _speed;

        /// <summary>
        /// ��������� ������ � ��������.
        /// </summary>
        [SerializeField] private int _cost;
        public int Cost => _cost;

        private FishingPlace _fishingPlace;
        public FishingPlace FishingPlace => _fishingPlace;

        public event Action<bool> OnFishingPlaceNearby;

        private Fish _lastCaughtFish = null;
        public Fish LastCaughtFish => _lastCaughtFish;


        #region UnityEvents
        private void Start()
        {
            Initialize(_asset);
        }

        /// <summary>
        /// ���������� ������, �� ������� ������� ���������� ����-���� ����� ����.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<FishingPlace>(out var fishingPlace))
            {
                _fishingPlace = fishingPlace;
                OnFishingPlaceNearby(true);
            }
        }

        /// <summary>
        /// ��������� ���������� ������, �� ������� ������� ���������� ����-���� ����� ����.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<FishingPlace>(out var fishingPlace))
            {
                _fishingPlace = null;
                OnFishingPlaceNearby(false);
            }
        }

        /// <summary>
        /// ��� �������� �������� ���������� ������ �������� ������ �� �����.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
        #endregion

        /// <summary>
        /// � ����������� �� ��������� ScriptableObject ������ ��������� ���������� ������.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishingRodAsset asset)
        {
            _speed = asset.Speed;
            _radius = asset.Radius;
            _cost = asset.Cost;

            _circleCollider.radius = _radius;
        }

        /// <summary>
        /// ��������� ���������� � ��������� ��������� ����.
        /// </summary>
        /// <param name="fish"></param>
        public void AssignFish(Fish fish)
        {
            _lastCaughtFish = fish;
        }
    }
}