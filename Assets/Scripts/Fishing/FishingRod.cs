using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShipMotorika
{
    /// <summary>
    /// ������ ������.
    /// </summary>
    public class FishingRod : MonoBehaviour
    {
        [SerializeField] private FishingRodAsset _asset;

        /// <summary>
        /// �������� ������ (��� ��������).
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;
        
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

        private FishingPoint _activeFishingPoint;
        public FishingPoint FishingPoint => _activeFishingPoint;

        public event Action<bool> OnFishingPlaceNearby;

        private Fish _lastCaughtFish = null;
        public Fish LastCaughtFish => _lastCaughtFish;

        private bool _isTriggered = false;

        #region UnityEvents
        private void Start()
        {
            Initialize(_asset);
        }

        /// <summary>
        /// ���������� ������, �� ������� ������� ���������� ����-���� ����� ����.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision) // ����
        {
            if (collision.TryGetComponent<FishingPoint>(out var fishingPoint)) // !!!!!!!!!!!!!!! Enter
            {
                if (!_isTriggered) // ������ �� ������������ ���������� FishingPoint ��� ��������� � �������.
                {
                    _isTriggered = true;
                    _activeFishingPoint = fishingPoint;
                    _activeFishingPoint.SetActive(true);
                    OnFishingPlaceNearby(true);
                }
            }
        }

        /// <summary>
        /// ��������� ���������� ������, �� ������� ������� ���������� ����-���� ����� ����.
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision) 
        {
            if (collision.TryGetComponent<FishingPoint>(out var fishingPoint))
            {
                _isTriggered = false;
                _activeFishingPoint = fishingPoint;
                _activeFishingPoint.SetActive(false);
                _activeFishingPoint = null;
                OnFishingPlaceNearby(false);

                FindFishNearby();
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// ��� �������� �������� ���������� ������ �������� ������ �� �����.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif
        #endregion

        /// <summary>
        /// �������������� �������� �� ���� ������. �� ������, ���� � ������� �������� ���� ��������� ����� ����, � ��������� ������ OnTriggerEnter.
        /// </summary>
        private void FindFishNearby()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);

            if (hits.Length > 0)
            {
                foreach (Collider2D hit in hits)
                {
                    if (hit.TryGetComponent<FishingPoint>(out var fishingPoint))
                    {
                        if (!_isTriggered)
                        {
                            _isTriggered = true;
                            _activeFishingPoint = fishingPoint;
                            _activeFishingPoint.SetActive(true);
                            OnFishingPlaceNearby(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// � ����������� �� ��������� ScriptableObject ������ ��������� ���������� ������.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishingRodAsset asset)
        {
            _name = asset.Name; 
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

        /// <summary>
        /// ��������� ��� ��������� ���� � �������� ���� �������.
        /// </summary>
        public void TryPutFishInShip()
        {
            if (_lastCaughtFish != null)
            {
                Player.Instance.Ship.TryChangeWeightAmount(_lastCaughtFish.Weight);
            }
        }
    }
}