using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create customers using user inputs
        Customer customer1 = CreateCustomerFromUserInput();
        Customer customer2 = CreateCustomerFromUserInput();

        // Create orders using user inputs
        Order order1 = CreateOrderFromUserInput(customer1);
        Order order2 = CreateOrderFromUserInput(customer2);

        // Display information
        Console.WriteLine("Order 1:");
        DisplayOrderInfo(order1);

        Console.WriteLine("\nOrder 2:");
        DisplayOrderInfo(order2);
    }

    static Customer CreateCustomerFromUserInput()
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter street address: ");
        string street = Console.ReadLine();

        Console.Write("Enter city: ");
        string city = Console.ReadLine();

        Console.Write("Enter state/province: ");
        string state = Console.ReadLine();

        Console.Write("Enter country: ");
        string country = Console.ReadLine();

        Address customerAddress = new Address(street, city, state, country);
        return new Customer(customerName, customerAddress);
    }

    static Order CreateOrderFromUserInput(Customer customer)
    {
        Order order = new Order(customer);

        Console.Write($"Enter the number of products for {customer.Name}'s order: ");
        int numProducts = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numProducts; i++)
        {
            Console.WriteLine($"Enter details for Product {i}:");

            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product ID: ");
            string productId = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new Product(productName, productId, price, quantity);
            order.AddProduct(product);
        }

        return order;
    }

    static void DisplayOrderInfo(Order order)
    {
        Console.WriteLine("Packing Label:\n" + order.GeneratePackingLabel());
        Console.WriteLine("Shipping Label:\n" + order.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;
    private double shippingCost;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
        shippingCost = customer.IsUSACustomer() ? 5.0 : 35.0;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.Price * product.Quantity;
        }
        return totalCost + shippingCost;
    }

    public string GeneratePackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"{product.Name} - {product.ProductId}\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name => name;
    public string ProductId => productId;
    public double Price => price;
    public int Quantity => quantity;
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name => name;
    public Address Address => address;

    public bool IsUSACustomer()
    {
        return address.IsUSAAddress();
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUSAAddress()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}
