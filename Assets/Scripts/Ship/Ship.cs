using ShipMotorika;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipAsset _asset;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody => rb2d;

    /// <summary>
    /// Стоимость корабля у торговца.
    /// </summary>
    [SerializeField] private int _cost;
    public int Cost => _cost;

    /// <summary>
    /// Грузоподъемность корабля. Не может быть меньше суммарного веса пойманной рыбы. 
    /// </summary>
    [SerializeField] private int _carrying;
    public int Carrying => _carrying;

    /// <summary>
    /// Текущий вес корабля с учетом пойманной рыбы.
    /// </summary>
    [SerializeField] private int _currentWeight;
    public int CurrentWeight => _currentWeight;

    private Sprite _sprite;

    private void Start()
    {
        Initialize(_asset);
    }

    /// <summary>
    /// В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
    /// </summary>
    /// <param name="asset"></param>
    public void Initialize(ShipAsset asset)
    {
        _sprite = asset.Sprite;
        _cost = asset.Cost;
        _carrying = asset.Сarrying;

        _spriteRenderer.sprite = _sprite;
    }
}