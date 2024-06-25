using UnityEngine;

namespace ShipMotorika
{
    namespace SpaceShooter
    {
        /// <summary>
        /// Очищает сцену от объектов перед закрытием. Нужен для работы в редакторе для очистки памяти.
        /// </summary>
        public class LevelCleaner : MonoBehaviour
        {
            private void OnDestroy()
            {
                CleanLevel();
            }

            private void CleanLevel()
            {
                void DestroyAll<T>() where T : MonoBehaviour
                {
                    foreach (var obj in FindObjectsOfType<T>())
                    {
                        Destroy(obj.gameObject);
                    }

                    DestroyAll<Fish>();
                    DestroyAll<FishContainer>();
                    DestroyAll<FishSpawner>();
                    DestroyAll<FishingChallenge>();
                    DestroyAll<FishingPoint>();
                    DestroyAll<FishingRod>();
                    DestroyAll<Market>();
                    DestroyAll<Player>();
                    DestroyAll<PlayerController>();
                    DestroyAll<Ship>();
                    DestroyAll<BoatShop>();
                    DestroyAll<Spawner>();
                    DestroyAll<Wallet>();
                }
            }
        }
    }
}