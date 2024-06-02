using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// �����, � ������� ����� ������ ����. � ������ ������ ��������� ������������ � ���� ����������� �������� ���������.
    /// </summary>
    public class FishingPlace : MonoBehaviour
    {
        /// <summary>
        /// � ���� ������ ���������� ��� "��������" ����/
        /// </summary>
        [SerializeField] private FishAsset[] _fishAssets;  
        
        /// <summary>
        /// �������� �������� ����-��������, �������� "�����" (���������� ��� ��������). ����� ��������� �� ������� ���������� ������ ������.
        /// </summary>
        [SerializeField] private FishAsset _bootAsset;

        [SerializeField] private Fish _fishPrefab;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Fish _fish;

        #region UnityEvents
        private void Start()
        {
            _spriteRenderer.enabled = true;
            
            FishingChallenge.Instance.OnTryCatchFish += ShowCatchedFish;
        }

        private void OnDestroy()
        {
            FishingChallenge.Instance.OnTryCatchFish -= ShowCatchedFish;
        }
        #endregion

        /// <summary>
        /// �������� �������� ��������� ��������� � ���� �������� ���� ��� "������".
        /// </summary>
        /// <param name="success"></param>
        private void ShowCatchedFish(bool success)
        {
            if (success)
            {
                _fish = Instantiate(_fishPrefab, transform.position, Quaternion.identity);
                _fish.Sprite.enabled = false; // Attention!

                // ���� ������� ����� - 10%.
                int random = Random.Range(0, 10);
                if (random == 0)
                {
                    _fish.Initialize(_bootAsset);
                }
                else
                {
                    int index = Random.Range(0, _fishAssets.Length);
                    _fish.Initialize(_fishAssets[index]);
                }

                Player.Instance.FishingRod.AssignFish(_fish);                
            }
            else
            {
                Player.Instance.FishingRod.AssignFish(null);;
            }

            FishingChallenge.Instance.OnDisable += DestroyItself;
        }

        private void DestroyItself()
        {         
            Destroy(gameObject);

            if (_fish != null)
            {
                Destroy(_fish.gameObject);
            }
            
            FishingChallenge.Instance.OnDisable -= DestroyItself;
        }
    }
}