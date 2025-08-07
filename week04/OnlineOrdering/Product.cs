namespace Week04.OnlineOrdering;

public class Product
{
    private readonly string _name;
    private readonly string _productId;
    private readonly decimal _pricePerUnit;
    private readonly int _quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (pricePerUnit < 0) throw new ArgumentOutOfRangeException(nameof(pricePerUnit));
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _productId = productId ?? throw new ArgumentNullException(nameof(productId));
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string Name => _name;
    public string ProductId => _productId;
    public decimal PricePerUnit => _pricePerUnit;
    public int Quantity => _quantity;

    public decimal TotalCost() => _pricePerUnit * _quantity;
}