using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Сохраняет в PlayerPrefs определенные данные.
    /// </summary>
    public class PlayerData
    {      
        #region Health
        public static void LoadHealth()
        {
            int health = PlayerPrefs.GetInt("ShipCurrentHealth", 0);

            Player.Instance.Ship.Health.SetCurrentHealth(health);
        }

        public static void SaveHealth()
        {
            int health = Player.Instance.Ship.Health.CurrentHealth;

            PlayerPrefs.SetInt("ShipCurrentHealth", health);
        }
        #endregion

        #region Money     
        public static void LoadMoney()
        {
            int money = PlayerPrefs.GetInt("PlayerMoney", 0);

            Player.Instance.Money.SetCurrentMoney(money);
        }

        public static void SaveMoney()
        {
            int money = Player.Instance.Money.CurrentMoney;

            PlayerPrefs.SetInt("PlayerMoney", money);
        }
        #endregion

        #region FishContainer
        public static void LoadFishContainer()
        {
            int weight = PlayerPrefs.GetInt("FishContainerWeight", 0);
            int cost = PlayerPrefs.GetInt("FishContainerCost", 0);

            var container = Player.Instance.Ship.FishContainer;

            container.SetFishWeight(weight);
            container.SetFishCost(cost);
        }

        public static void SaveFishContainer()
        {
            var container = Player.Instance.Ship.FishContainer;

            int weight = container.Weight;
            int cost = container.Cost;

            PlayerPrefs.SetInt("FishContainerWeight", weight);
            PlayerPrefs.SetInt("FishContainerCost", cost);
        }
        #endregion

        public void DeleteData()
        {
            PlayerPrefs.DeleteKey("PlayerMoney");
            PlayerPrefs.DeleteKey("ShipCurrentHealth");
            PlayerPrefs.DeleteKey("FishContainerWeight");
            PlayerPrefs.DeleteKey("FishContainerCost");

            FileHandler.Reset("ShipPosition.dat");
        }
    }
}