using System;
using System.Collections.Generic;

// Base class for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name)
    {
        Name = name;
        Points = 0;
        IsComplete = false;
    }

    public abstract void RecordEvent();
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    public override void RecordEvent()
    {
        IsComplete = true;
        Console.WriteLine($"{Name} completed! You earned {Points} points.");
    }
}

// Eternal goal that is never complete
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} recorded! You earned {Points} points.");
    }
}

// Checklist goal that must be accomplished a certain number of times
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;

    public int TargetCount { get { return targetCount; } }
    public int CompletedCount { get { return completedCount; } }

    public ChecklistGoal(string name, int points, int targetCount) : base(name)
    {
        Points = points;
        this.targetCount = targetCount;
        completedCount = 0;
    }

    public override void RecordEvent()
    {
        completedCount++;
        Console.WriteLine($"{Name} recorded! You earned {Points} points.");

        if (completedCount == targetCount)
        {
            IsComplete = true;
            Console.WriteLine($"Congratulations! {Name} completed with a bonus of {Points * 2} points.");
        }
    }
}

// Class to manage goals and scores
public class EternalQuest
{
    private List<Goal> goals;
    private int totalScore;

    public EternalQuest()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - {(goal.IsComplete ? "[X]" : "[ ]")}");
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"Completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount} times");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }
    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to mark off:");
        DisplayGoals();

        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            MarkOffGoal(goalIndex);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal index.");
        }
    }

    private void MarkOffGoal(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Sample usage
        var quest = new EternalQuest();
        quest.AddGoal(new SimpleGoal("Run a marathon", 1000));
        quest.AddGoal(new EternalGoal("Read scriptures", 100));
        quest.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        quest.RecordEvent(); // Let the user select a goal to mark off

        quest.DisplayGoals();
        quest.DisplayScore();
    }
}
