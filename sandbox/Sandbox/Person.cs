public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void SayHello()
    {
        
    }

    public int GetAge()
    {
        return 0; // Placeholder return value
    }

    public DateTime GetBirthdate()
    {
        return DateTime.MinValue; // Placeholder return value
    }
}