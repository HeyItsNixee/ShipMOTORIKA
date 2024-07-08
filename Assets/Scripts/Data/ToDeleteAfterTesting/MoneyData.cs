//using UnityEngine;
//using UnityEngine.SceneManagement;

//namespace ShipMotorika
//{
//    /// <summary>
//    /// Оперирует данными о деньгах игрока.
//    /// </summary>
//    public static class MoneyData
//    {
//        private const string Filename = "PlayerMoney";

//        public static void Load()
//        {
//            int money = PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}_{Filename}", 0);

//            Player.Instance.Money.SetCurrentMoney(money);
//        }

//        public static void Save()
//        {
//            int money = Player.Instance.Money.CurrentMoney;

//            PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_{Filename}", money);
//        }

//        public static void DeleteSceneData(string sceneName)
//        {
//            PlayerPrefs.DeleteKey($"{sceneName}_{Filename}");
//        }
//    }
//}