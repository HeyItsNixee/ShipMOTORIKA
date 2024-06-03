using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// ������ �������� ��������� ����� ����.
    /// </summary>
    [CreateAssetMenu]
    public class FishAsset : ScriptableObject
    {
        public Sprite Sprite;
        public int Cost;
        public int Weight;
    }
}