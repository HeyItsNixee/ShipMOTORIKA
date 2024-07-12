using System.IO;
using UnityEngine;

namespace ShipMotorika
{
    public static class FileHandler
    {
        public static string Path(string filename)
        {
            return $"{Application.persistentDataPath}/{filename}";
        }

        public static void CreateEmptyFile(string filename)
        {
            var path = Path(filename);

            File.Create(path);
        }

        public static void Reset(string filename)
        {
            var path = Path(filename);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static bool HasFile(string filename)
        {
            return File.Exists(Path(filename));
        }
    }
}