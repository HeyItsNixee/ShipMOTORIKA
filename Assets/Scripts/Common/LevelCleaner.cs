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

                    DestroyAll<ActionButton>();
                    DestroyAll<BoatShop>();
                    DestroyAll<FishingRodShop>();
                    DestroyAll<CircleArea>();
                    DestroyAll<Fish>();
                    DestroyAll<FishAlbum>();
                    DestroyAll<FishContainer>();
                    DestroyAll<FishPool>();
                    DestroyAll<FishSpawner>();
                    DestroyAll<FishingChallenge>();
                    DestroyAll<FishingPoint>(); 
                    DestroyAll<FishingRod>();
                    DestroyAll<FishingRodRotator>();
                    DestroyAll<FishingRodRotator_old>();
                    DestroyAll<Health>();
                    DestroyAll<Market>();
                    DestroyAll<Money>();
                    DestroyAll<Player>();
                    DestroyAll<PlayerController>();
                    DestroyAll<RestorePoint>();
                    DestroyAll<Rotator>();
                    DestroyAll<Ship>();
                    DestroyAll<ShipDestroyer>();
                    DestroyAll<ShipRestorer>();                   
                    DestroyAll<Spawner>();
                    DestroyAll<Workshop>();                 
                }
            }
        }
    }
}