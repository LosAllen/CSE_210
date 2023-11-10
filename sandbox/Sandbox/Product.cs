public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public string GetDescription()
    {
        return ""; // Placeholder return value
    }

    public decimal GetPrice()
    {
        return 0.0m; // Placeholder return value
    }
}