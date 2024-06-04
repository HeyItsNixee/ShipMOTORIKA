using ShipMotorika;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody => rb2d;

    [SerializeField] private ShipAsset _asset;

    /// <summary>
    /// ���������� ����������� �������. � ������ ������ ��� �������� �� ����� �������� ���������� ���������� � ������ � ��������� ������.
    /// </summary>
    [SerializeField] private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// �������� ������� ��� ����������.
    /// </summary>
    [SerializeField] private string _name;
    public string Name => _name;

    /// <summary>
    /// ��������� ������� � ��������.
    /// </summary>
    [SerializeField] private int _cost;
    public int Cost => _cost;

    /// <summary>
    /// ���������������� �������. �� ����� ���� ������ ���������� ���� ��������� ����.
    /// </summary>
    [SerializeField] private int _carryingCapacity;
    public int Carrying => _carryingCapacity;

    /// <summary>
    /// ������� ��� �������. ��������������� ���� ��� �������� ����������.
    /// </summary>
    [SerializeField] private int _currentWeight;
    public int CurrentWeight => _currentWeight;

    private void Start()
    {
        Initialize(_asset);
    }

    /// <summary>
    ///  � ����������� �� ��������� ScriptableObject ������ ��������� ���������� ������.
    /// </summary>
    /// <param name="asset"></param>
    public void Initialize(ShipAsset asset)
    {
        _spriteRenderer.sprite = asset.Sprite;
        _name = asset.Name;
        _cost = asset.Cost;
        _carryingCapacity = asset.�arryingCapacity;
    }

    /// <summary>
    /// ��� ����� ���� ����� ��������� ������ �����. 
    /// </summary>
    /// <param name="amount"></param>
    public void TryChangeWeightAmount(int amount)
    {
        int currentWeight = _currentWeight + amount;

        if (currentWeight >= 0 || currentWeight <= _carryingCapacity)
        {
            _currentWeight = currentWeight;
        }
    }
}