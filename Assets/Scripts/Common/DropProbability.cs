using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Возвращает вероятность выпадения предмета от 0 до 100%
    /// </summary>
    public static class DropProbability
    {
        public static int Value
        {
            get
            {
                int random = Random.Range(0, 101);
                return random;
            }
        }
    }
}