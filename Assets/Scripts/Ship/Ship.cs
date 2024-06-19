using ShipMotorika;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody => rb2d;

    /// <summary>
    /// ScriptableObject c параметрами корабля.
    /// </summary>
    [SerializeField] private ShipAsset _asset;

    /// <summary>
    /// Визуальное отображение корабля. В данном случае для удобства не стоит выделять визуальное воплощение и модель в отдельные классы.
    /// </summary>
    [SerializeField] private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Коллайдер столкновений спрайта корабля.
    /// </summary>
    [SerializeField] private CapsuleCollider2D _capsuleCollider;

    /// <summary>
    /// Название корабля для интерфейса.
    /// </summary>
    [SerializeField] private string _name;
    public string Name => _name;

    /// <summary>
    /// Художественное описание корабля. 
    /// </summary>
    [SerializeField] private string _description;
    public string Description => _description;

    /// <summary>
    /// Стоимость корабля у торговца.
    /// </summary>
    [SerializeField] private int _cost;
    public int Cost => _cost;

    /// <summary>
    /// Грузоподъемность корабля. Не может быть меньше суммарного веса собранной рыбы.
    /// </summary>
    [SerializeField] private int _carryingCapacity;
    public int CarryingCapacity => _carryingCapacity;

    /// <summary>
    /// Текущий вес корабля. Сериализованное поле нужно для удобства разработки.
    /// </summary>
    [SerializeField] private int _currentWeight;
    public int CurrentWeight => _currentWeight;

    /// <summary>
    /// Скорость корабля (MaxLinearVelocity).
    /// </summary>
    [SerializeField] private float _speed;
    public float Speed => _speed;   

    /// <summary>
    /// Отсек для хранения рыбы.
    /// </summary>
    [SerializeField] private FishContainer _fishContainer;
    public FishContainer FishContainer => _fishContainer;

    public event Action<bool> OnMarketNearby;
    public event Action<bool> OnShopNearby;
    public event Action OnWeightChanged;

    #region UnityEvents
    private void Start()
    {
        Initialize(_asset);

        _fishContainer.OnFishCaught += TryChangeWeightAmount;
    }

    private void OnDestroy()
    {
        _fishContainer.OnFishCaught -= TryChangeWeightAmount;
    }
    #endregion

    /// <summary>
    ///  В зависимости от заданного ScriptableObject задает параметры экземпляра класса.
    /// </summary>
    /// <param name="asset"></param>
    public void Initialize(ShipAsset asset)
    {
        _spriteRenderer.sprite = asset.GameSprite;
        _capsuleCollider.size = new Vector2(_asset.ColliderX, _asset.ColliderY);    
        _name = asset.Name;
        _description = asset.Description;
        _cost = asset.Cost;
        _carryingCapacity = asset.СarryingCapacity;
        _speed = asset.Speed;
        
        Player.Instance.PlayerController.SetMaxLinearVelocity(_speed);
    }

    /// <summary>
    /// Сообщает о том, что корабль вблизи рынка.
    /// </summary>
    /// <param name="value"></param>
    public void SendMarketMessage(bool value)
    {
        OnMarketNearby?.Invoke(value);
    }

    /// <summary>
    /// Сообщает о том, что корабль вблизи магазина.
    /// </summary>
    /// <param name="value"></param>
    public void SendShopMessage(bool value)
    {
        OnShopNearby?.Invoke(value);
    }

    public void TryChangeWeightAmount(int amount)
    {
        int currentWeight = _currentWeight + amount;

        if (currentWeight >= 0 || currentWeight <= _carryingCapacity)
        {
            _currentWeight = currentWeight;

            OnWeightChanged?.Invoke();
        }
    }
}