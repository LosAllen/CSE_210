using System;
using System.Threading;

interface IActivity
{
    void StartActivity();
}

class Activity : IActivity
{
    protected int duration;

    public Activity()
    {
        Console.WriteLine("Welcome to the Activity App!");
    }

    public void StartActivity()
    {
        SetDuration();
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine("Get ready to start!");
        Pause(3);
    }

    protected virtual void PerformActivity()
    {
        // Base activity does nothing
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine("Great job! You've completed the activity.");
        Console.WriteLine($"Time spent: {duration} seconds");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        // Simulate pause with a spinner
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}


class BreathingActivity : Activity
{
    protected override void SetDuration()
    {
        base.SetDuration();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            CountdownAndPause(3);

            Console.WriteLine("Breathe out...");
            CountdownAndPause(3);
        }
    }

    private void CountdownAndPause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i}");
            Thread.Sleep(1000);
        }
        Pause(1); // Pause for an additional second after the countdown
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    protected override void SetDuration()
    {
        base.SetDuration();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Let's begin reflecting...");

        Random rand = new Random();

        for (int i = 0; i < duration; i++)
        {
            // Select a random prompt
            string randomPrompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(randomPrompt);

            // Ask reflection questions
            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine(question);
                SpinnerPause(3); // Display a spinner while pausing
            }
        }
    }

    private void SpinnerPause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ListingActivity : Activity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override void SetDuration()
    {
        base.SetDuration();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Let's begin listing...");

        Random rand = new Random();
        string randomListingPrompt = listingPrompts[rand.Next(listingPrompts.Length)];
        Console.WriteLine(randomListingPrompt);

        Console.WriteLine($"You have {duration} seconds to begin thinking about the prompt...");
        CountdownAndPause(duration);

        Console.WriteLine("Now, start listing items:");

        // Simulate user listing items for the specified duration
        Thread.Sleep(duration * 1000);

        // Display the number of items entered
        Console.WriteLine($"You listed a total of X items.");
    }

    private void CountdownAndPause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i}");
            Thread.Sleep(1000);
        }
        Pause(1); // Pause for an additional second after the countdown
    }
}


class Program
{
    static void Main()
    {
        // Menu system
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        Console.Write("Enter your choice (1-3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Activity selectedActivity = null;

        switch (choice)
        {
            case 1:
                selectedActivity = new BreathingActivity();
                break;
            case 2:
                selectedActivity = new ReflectionActivity();
                break;
            case 3:
                selectedActivity = new ListingActivity();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                Environment.Exit(0);
                break;
        }

        // Start the selected activity
        selectedActivity.StartActivity();
    }
}