using System;

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
                Random random = new();
                int randomNumber = random.Next(101);
                return randomNumber;
            }
        }
    }
}