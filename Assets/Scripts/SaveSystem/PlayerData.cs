using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Сохраняет данные пользователя.
    /// </summary>
    public class PlayerData
    {
        public static void DeleteSceneData(string sceneName)
        {
            FishContainerData.DeleteSceneData(sceneName);
            HealthData.DeleteSceneData(sceneName);
            MoneyData.DeleteSceneData(sceneName);
            ShipAssetData.DeleteSceneData(sceneName);
            ShipPositionData.DeleteSceneData(sceneName);           
        }

        public static void Reset()
        {
            PlayerPrefs.DeleteAll();

            HealthData.DeleteSceneData("TestScene_kirvas");
            HealthData.DeleteSceneData("Nixee_World");
            HealthData.DeleteSceneData("Tutorial");

            MoneyData.DeleteSceneData("TestScene_kirvas");
            MoneyData.DeleteSceneData("Nixee_World");
            MoneyData.DeleteSceneData("Tutorial");

            FishContainerData.DeleteSceneData("TestScene_kirvas");
            FishContainerData.DeleteSceneData("Nixee_World");
            FishContainerData.DeleteSceneData("Tutorial");

            ShipAssetData.DeleteSceneData("TestScene_kirvas");
            ShipAssetData.DeleteSceneData("Nixee_World");
            ShipAssetData.DeleteSceneData("Tutorial");

            ShipPositionData.DeleteSceneData("TestScene_kirvas");
            ShipPositionData.DeleteSceneData("Nixee_World");
            ShipPositionData.DeleteSceneData("Tutorial");
        }
    }
}