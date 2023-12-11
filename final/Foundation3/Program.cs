using System;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string Title { get { return title; } }
    public string Description { get { return description; } }
    public DateTime Date { get { return date; } }
    public TimeSpan Time { get { return time; } }
    public Address Address { get { return address; } }

    public string GenerateStandardMessage()
    {
        return $"Event: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GenerateFullMessage()
    {
        return GenerateStandardMessage();
    }

    public string GenerateShortDescription()
    {
        return $"Event Type: Generic\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Outdoor Gathering\nWeather Statement: {weatherStatement}";
    }
}

class Program
{
    static void Main()
    {
        // Get user inputs for each event
        Console.WriteLine("Enter details for the Generic Event:");
        Event genericEvent = GetUserInputForEvent();

        Console.WriteLine("\nEnter details for the Tech Talk (Lecture):");
        Lecture lectureEvent = GetUserInputForLecture();

        Console.WriteLine("\nEnter details for the Networking Mixer (Reception):");
        Reception receptionEvent = GetUserInputForReception();

        Console.WriteLine("\nEnter details for the Summer Picnic (Outdoor Gathering):");
        OutdoorGathering outdoorEvent = GetUserInputForOutdoorGathering();

        // Display generated messages for each event
        Console.WriteLine("\nGenerated Messages:");
        Console.WriteLine("\nGeneric Event:\n" + genericEvent.GenerateStandardMessage() + "\n");
        Console.WriteLine("Tech Talk:\n" + lectureEvent.GenerateFullMessage() + "\n");
        Console.WriteLine("Networking Mixer:\n" + receptionEvent.GenerateShortDescription() + "\n");
        Console.WriteLine("Summer Picnic:\n" + outdoorEvent.GenerateFullMessage() + "\n");
    }

    static Event GetUserInputForEvent()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Date (MM/DD/YYYY): ");
        t

        Console.Write("Time (HH:mm): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Street Address: ");
        string street = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip Code: ");
        string zipCode = Console.ReadLine();

        Address address = new Address(street, city, state, zipCode);

        return new Event(title, description, date, time, address);
    }

    static Lecture GetUserInputForLecture()
    {
        Event baseEvent = GetUserInputForEvent();

        Console.Write("Speaker: ");
        string speaker = Console.ReadLine();

        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        return new Lecture(baseEvent.Title, baseEvent.Description, baseEvent.Date, baseEvent.Time, baseEvent.Address, speaker, capacity);
    }

    static Reception GetUserInputForReception()
    {
        Event baseEvent = GetUserInputForEvent();

        Console.Write("RSVP Email: ");
        string rsvpEmail = Console.ReadLine();

        return new Reception(baseEvent.Title, baseEvent.Description, baseEvent.Date, baseEvent.Time, baseEvent.Address, rsvpEmail);
    }

    static OutdoorGathering GetUserInputForOutdoorGathering()
    {
        Event baseEvent = GetUserInputForEvent();

        Console.Write("Weather Statement: ");
        string weatherStatement = Console.ReadLine();

        return new OutdoorGathering(baseEvent.Title, baseEvent.Description, baseEvent.Date, baseEvent.Time, baseEvent.Address, weatherStatement);
    }
}
