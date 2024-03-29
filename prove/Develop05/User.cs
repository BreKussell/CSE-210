using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class User
{
    private static int Score = 0;
    private static int Level = 1;
    private static int PointsForNextLevel = 1000; // Initial points needed for the next level.
    public static List<Goal> Goals = new List<Goal>();

    public static void AddPoints(int points)
    {
        Score += points;
        CheckLevelUp();
        DisplayProgressBar(); // Display progress bar after adding points and checking for level up
    }

    private static void CheckLevelUp()
    {
        while (Score >= PointsForNextLevel)
        {
            Score -= PointsForNextLevel; // Deduct the points needed for the level-up.
            Level++;
            PointsForNextLevel += 500; // Increase the points required for the next level.
            Console.WriteLine($"Level up! {Level}!");
            DisplayProgressBar(); // Optionally, display the progress bar to show it's reset after leveling up
        }
    }

    public static void ShowGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public static void ShowScoreAndLevel()
    {
    
        DisplayProgressBar();
        Console.WriteLine($"Your current score is: {Score}");
        Console.WriteLine($"Your current level is: {Level}");
        Console.WriteLine($"Points needed for next level: {PointsForNextLevel - Score}");
    }

    public static void SaveUserData()
    {
        var serializedGoals = JsonConvert.SerializeObject(Goals);
        var serializedUserData = JsonConvert.SerializeObject(new { Score, Level, PointsForNextLevel });
        File.WriteAllText("goals.json", serializedGoals);
        File.WriteAllText("userData.json", serializedUserData);
    }

    public static void LoadUserData()
    {
        if (File.Exists("goals.json"))
        {
            var serializedGoals = File.ReadAllText("goals.json");
            Goals = JsonConvert.DeserializeObject<List<Goal>>(serializedGoals, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        if (File.Exists("userData.json"))
        {
            var serializedUserData = File.ReadAllText("userData.json");
            var userData = JsonConvert.DeserializeObject<dynamic>(serializedUserData);
            Score = userData.Score;
            Level = userData.Level;
            PointsForNextLevel = userData.PointsForNextLevel;
        }
    }
    
    public static void DisplayProgressBar()
    {
        // Calculate the percentage of points earned towards the next level
        double percentage = (double)Score / PointsForNextLevel * 100;

        // Define the length of the progress bar
        int progressBarLength = 50; // This can be adjusted to your preference
        int fillLength = (int)(percentage / 100 * progressBarLength);
        string progressBarFill = new string('=', fillLength);
        string progressBarEmpty = new string(' ', progressBarLength - fillLength);

        Console.WriteLine($"Level {Level} Progress: [{progressBarFill}{progressBarEmpty}] {percentage:0.00}%");
    }

}