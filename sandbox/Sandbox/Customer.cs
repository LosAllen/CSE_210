public class Customer
{
    public int CustomerID { get; set; }
    public int LoyaltyPoints { get; set; }

    public void Purchase(Product item)
    {

    }

    public int GetLoyaltyPoints()
    {
        return 0; // Placeholder return value
    }
}