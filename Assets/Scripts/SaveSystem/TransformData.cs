using System;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Вспомогательный класс для сохранения позиции точки возрождения корабля.
    /// </summary>
    [Serializable]
    public class TransformData : MonoBehaviour
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
    }
}