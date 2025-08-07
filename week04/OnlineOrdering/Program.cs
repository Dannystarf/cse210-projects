using Week04.OnlineOrdering;

// Create customers and addresses
var addr1 = new Address("123 Maple St", "Boise", "ID", "USA");
var cust1 = new Customer("Ava Johnson", addr1);

var addr2 = new Address("221B Baker St", "London", "Greater London", "United Kingdom");
var cust2 = new Customer("Noah Williams", addr2);

// Create orders and products
var order1 = new Order(cust1);
order1.AddProduct(new Product("Notebook", "P100", 3.50m, 5));
order1.AddProduct(new Product("Gel Pen", "P200", 1.25m, 10));
order1.AddProduct(new Product("Stapler", "P300", 7.99m, 1));

var order2 = new Order(cust2);
order2.AddProduct(new Product("USB-C Cable", "C100", 9.99m, 2));
order2.AddProduct(new Product("Laptop Stand", "L300", 29.95m, 1));

// Show output
var orders = new List<Order> { order1, order2 };

int index = 1;
foreach (var order in orders)
{
    Console.WriteLine($"Order {index}");
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine($"Total Price: ${order.TotalPrice():0.00}");
    Console.WriteLine(new string('-', 50));
    index++;
}