using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipMotorika
{
    /// <summary>
    /// Оперирует данными о контейнере с рыбой (вес и стоимость пойманной рыбы).
    /// </summary>
    public static class FishContainerData
    {
        private const string WeightFilename = "FishContainerWeight";
        private const string CostFilename = "FishContainerCost";

        public static void Load()
        {
            int weight = PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}_{WeightFilename}", 0);
            int cost = PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}_{CostFilename}", 0);

            var container = Player.Instance.Ship.FishContainer;

            container.SetFishWeight(weight);
            container.SetFishCost(cost);
        }

        public static void Save()
        {
            var container = Player.Instance.Ship.FishContainer;

            int weight = container.Weight;
            int cost = container.Cost;

            PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_{WeightFilename}", weight);
            PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_{CostFilename}", cost);
        }

        public static void DeleteSceneData(string sceneName)
        {
            PlayerPrefs.DeleteKey($"{sceneName}_{WeightFilename}");
            PlayerPrefs.DeleteKey($"{sceneName}_{CostFilename}");
        }
    }
}