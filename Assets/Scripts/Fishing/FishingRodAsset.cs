using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ������ �������� ��������� ����� ������.
    /// </summary>
    [CreateAssetMenu]
    public class FishingRodAsset : ScriptableObject
    {
        public Sprite Sprite;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}