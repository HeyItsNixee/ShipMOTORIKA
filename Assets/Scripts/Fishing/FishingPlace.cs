using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Место, в котором можно ловить рыбу. В данный момент визуально отображается в виде зацикленной анимации пузырьков.
    /// </summary>
    public class FishingPlace : MonoBehaviour
    {
        /// <summary>
        /// В этот массив складываем всю "полезную" рыбу/
        /// </summary>
        [SerializeField] private FishAsset[] _fishAssets;  
        
        /// <summary>
        /// Отдельно выделяем рыбу-пустышку, например "сапог" (специально для Анжелики). Можно расширить до массива отдельного класса НЕрыбы.
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
        /// Рандомом получает случайный результат в виде полезной рыбы или "сапога".
        /// </summary>
        /// <param name="success"></param>
        private void ShowCatchedFish(bool success)
        {
            if (success)
            {
                _fish = Instantiate(_fishPrefab, transform.position, Quaternion.identity);
                _fish.Sprite.enabled = false; // Attention!

                // Шанс поймать сапог - 10%.
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