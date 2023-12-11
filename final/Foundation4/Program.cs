using System;

class Activity
{
    private string _date;
    private int _length;

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public virtual double GetDistance()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetSpeed()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual double GetPace()
    {
        return 0; // To be overridden in derived classes
    }

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min)";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(string date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / base.GetDistance() * 60;
    }

    public override double GetPace()
    {
        return base.GetDistance() / _distance;
    }

    public override string GetSummary()
    {
        string distanceUnit = "miles";
        string speedUnit = "mph";
        string paceUnit = "min per mile";
        return $"{base.GetSummary()} - Distance {GetDistance()} {distanceUnit}, Speed {GetSpeed():F1} {speedUnit}, Pace: {GetPace():F1} {paceUnit}";
    }
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override string GetSummary()
    {
        string speedUnit = "kph";
        return $"{base.GetSummary()} - Speed: {GetSpeed():F1} {speedUnit}";
    }
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    public override string GetSummary()
    {
        string distanceUnit = "km";
        return $"{base.GetSummary()} - Distance {GetDistance():F1} {distanceUnit}";
    }
}

class Program
{
    static void Main()
    {
        var activities = new Activity[3];

        // Get user inputs
        Console.Write("Enter date (DD MMM YYYY): ");
        string date = Console.ReadLine();

        Console.Write("Enter length of activity in minutes: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter running distance in miles: ");
        double distance = double.Parse(Console.ReadLine());
        activities[0] = new Running(date, length, distance);

        Console.Write("Enter cycling speed in kph: ");
        double speed = double.Parse(Console.ReadLine());
        activities[1] = new Cycling(date, length, speed);

        Console.Write("Enter swimming laps: ");
        int laps = int.Parse(Console.ReadLine());
        activities[2] = new Swimming(date, length, laps);

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
