using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public abstract class Goal
{
    public string Name { get; set; }
    public bool IsComplete { get; protected set; }
    public abstract void RecordEvent();
    public abstract string GetStatus();
    protected int Points { get; set; }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            User.AddPoints(Points);
            IsComplete = true;
        }
    }

    public override string GetStatus() => IsComplete ? "[X] " + Name : "[ ] " + Name;
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int pointsPerEvent)
    {
        Name = name;
        Points = pointsPerEvent;
        IsComplete = false; // Always false for eternal goals.
    }

    public override void RecordEvent()
    {
        User.AddPoints(Points);
    }

    public override string GetStatus() => "[ ] " + Name;
}

class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int BonusPoints;

    public ChecklistGoal(string name, int pointsPerEvent, int targetCount, int bonusPoints)
    {
        Name = name;
        Points = pointsPerEvent;
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
        IsComplete = false;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        User.AddPoints(Points);
        if (CurrentCount >= TargetCount)
        {
            User.AddPoints(BonusPoints);
            IsComplete = true;
        }
    }

    public override string GetStatus() => IsComplete ? $"[X] {Name} (Completed {CurrentCount}/{TargetCount} times)" : $"[ ] {Name} (Completed {CurrentCount}/{TargetCount} times)";
}