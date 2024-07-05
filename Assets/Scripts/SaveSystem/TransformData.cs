using System;
using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ��������������� ����� ��� ���������� ������� ����� ����������� �������.
    /// </summary>
    [Serializable]
    public class TransformData : MonoBehaviour
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
    }
}