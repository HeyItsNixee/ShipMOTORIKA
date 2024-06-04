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
        public string Name;
        public float Radius;
        public float Speed;
        public int Cost;
    }
}