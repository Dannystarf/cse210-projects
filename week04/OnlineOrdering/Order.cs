using System.Text;

namespace Week04.OnlineOrdering;

public class Order
{
    private readonly List<Product> _products = new();
    private readonly Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }

    public Customer Customer => _customer;

    public void AddProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        _products.Add(product);
    }

    public decimal TotalPrice()
    {
        decimal subtotal = 0m;
        foreach (var p in _products)
        {
            subtotal += p.TotalCost();
        }
        return subtotal + ShippingCost();
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Packing Label");
        foreach (var p in _products)
        {
            sb.AppendLine($"- {p.Name} (ID: {p.ProductId}) x{p.Quantity}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label\n{_customer.Name}\n{_customer.Address.ToMultilineString()}";
    }

    private decimal ShippingCost() => _customer.LivesInUSA() ? 5m : 35m;
}