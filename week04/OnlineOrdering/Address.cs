namespace Week04.OnlineOrdering;

public class Address
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _stateOrProvince;
    private readonly string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street ?? throw new ArgumentNullException(nameof(street));
        _city = city ?? throw new ArgumentNullException(nameof(city));
        _stateOrProvince = stateOrProvince ?? string.Empty;
        _country = country ?? throw new ArgumentNullException(nameof(country));
    }

    public bool IsInUSA()
    {
        var c = _country.Trim().ToUpperInvariant();
        return c is "USA" or "UNITED STATES" or "UNITED STATES OF AMERICA" or "US";
    }

    public string ToMultilineString()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}