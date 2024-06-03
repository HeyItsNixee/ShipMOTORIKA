using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// �������� ������� ���� �� ����. ����.
    /// </summary>
    public class Fish : MonoBehaviour
    {
        /// <summary>
        /// ���������� ����������� ���� � ����������
        /// </summary>
        [SerializeField] private SpriteRenderer _sprite;
        public SpriteRenderer Sprite => _sprite;

        /// <summary>
        /// �������� ����. ��� ��������� ����������.
        /// </summary>
        [SerializeField] private string _name;
        public string Name => _name;

        /// <summary>
        /// ��������� ���� ��� �������
        /// </summary>
        private int _cost;
        public int Cost => _cost;

        /// <summary>
        /// ��� ��������� ����. ��������� ��� ���� ��������� ���� �� ����� ��������� ���������������� �������.
        /// </summary>
        private int _weight;
        public int Weight => _weight;   

        /// <summary>
        /// � ����������� �� ��������� ScriptableObject ������ ��������� ���������� ������.
        /// </summary>
        /// <param name="asset"></param>
        public void Initialize(FishAsset asset)
        {
            _sprite.sprite = asset.Sprite;
            _name = asset.Name; 
            _cost = asset.Cost;
            _weight = asset.Weight;
        }
    }
}