//using System;
//using System.Collections.Generic;

//namespace ShipMotorika
//{
//    //public class PersistentDataHandler : SingletonBase<PersistentDataHandler>, ILoader, ISaver
//    //{
//    //    [Serializable]
//    //    public sealed class SceneDataStorage
//    //    {
//    //        public List<SceneData> AllSceneData;
//    //    }  

//    //    private const string Filename = "Save.json";

//        //private static List<ILoader> _loaders = new List<ILoader>();
//        //public static List<ILoader> Loaders => _loaders;

//        //private static List<ISaver> _savers = new List<ISaver>();
//        //public static List<ISaver> Savers => _savers;

//        //private SceneDataStorage _saveData;

//        //private new void Awake()
//        //{          
//        //    _loaders.Add(this);
//        //    _savers.Add(this);
//        //}

//        //private void Start()
//        //{
//        //    foreach (var loader in _loaders)
//        //    {
//        //        loader.Load();
//        //    }
//        //}

//        //private void OnDestroy()
//        //{
//        //    foreach (var saver in _savers)
//        //    {
//        //        saver.Save();
//        //    }

//        //    _loaders.Clear();
//        //    _savers.Clear();
//        //}

//        //public bool HasSave()
//        //{
//        //    return FileHandler.HasFile($"{Filename}");
//        //}

//        //public void Load()
//        //{
//        //    Saver<SceneDataStorage>.TryLoad($"{Filename}", ref _saveData);
//        //}

//        //public void Save()
//        //{
//        //    Saver<SceneDataStorage>.Save($"{Filename}", _saveData);
//        //}

//        //public void Delete()
//        //{
//        //    string filePath = $"{Filename}";

//        //    if (FileHandler.HasFile(filePath))
//        //    {
//        //        FileHandler.Reset(filePath);
//        //    }
//        //}
//    }
//}