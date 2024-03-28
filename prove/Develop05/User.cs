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
    }

    private static void CheckLevelUp()
    {
        while (Score >= PointsForNextLevel)
        {
            Score -= PointsForNextLevel; // Deduct the points needed for the level-up.
            Level++;
            PointsForNextLevel += 500; // Increase the points required for the next level.
            Console.WriteLine($"Level up! {Level}!");
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
}