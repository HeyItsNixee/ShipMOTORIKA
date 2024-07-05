using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    /// Оперирует данными о здоровье корабля игрока.
    /// </summary>
    public static class HealthData
    {
        private const string Filename = "ShipCurrentHealth";

        public static void Load()
        {
            int health = PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}_{Filename}", 0);

            Player.Instance.Ship.Health.SetCurrentHealth(health);
        }

        public static void Save()
        {
            int health = Player.Instance.Ship.Health.CurrentHealth;

            PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_{Filename}", health);
        }

        public static void DeleteSceneData(string sceneName)
        {
            PlayerPrefs.DeleteKey($"{sceneName}_{Filename}");
        }
    }
}