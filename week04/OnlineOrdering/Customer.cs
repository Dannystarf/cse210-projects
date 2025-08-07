namespace Week04.OnlineOrdering;

public class Customer
{
    private readonly string _name;
    private readonly Address _address;

    public Customer(string name, Address address)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public string Name => _name;
    public Address Address => _address;

    public bool LivesInUSA() => _address.IsInUSA();

    public override string ToString()
    {
        return $"{_name}\n{_address.ToMultilineString()}";
    }
}