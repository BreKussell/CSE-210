using System;

class Program
{
    static void Main(string[] args)
    {
        // Load existing user data and goals from files.
        User.LoadUserData();

        // Example interaction loop.
        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("Goal Tracker Application");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Goal Completion");
            Console.WriteLine("4. Show Score and Level");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    User.ShowGoals();
                    break;
                case "2":
                    AddGoal();
                    break;
                case "3":
                    RecordGoalCompletion();
                    break;
                case "4":
                    User.ShowScoreAndLevel();
                    break;
                case "5":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            if (!exitProgram)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Save user data and goals before exiting.
        User.SaveUserData();
    }

   private static void AddGoal()
{
    Console.WriteLine("What type of goal would you like to add?");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.Write("Select an option: ");
    string goalType = Console.ReadLine();

    Console.Write("Enter the name of the goal: ");
    string name = Console.ReadLine();

    Console.Write("Enter the points for completing the goal: ");
    int points = int.Parse(Console.ReadLine()); 

    switch (goalType)
    {
        case "1": // Simple Goal
            User.Goals.Add(new SimpleGoal(name, points));
            break;
        case "2": // Eternal Goal
            User.Goals.Add(new EternalGoal(name, points));
            break;
        case "3": // Checklist Goal
            Console.Write("Enter the target count for the goal: ");
            int targetCount = int.Parse(Console.ReadLine()); 

            Console.Write("Enter the bonus points for completing the goal: ");
            int bonusPoints = int.Parse(Console.ReadLine()); 

            User.Goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    Console.WriteLine("Goal added successfully.");
}

 private static void RecordGoalCompletion()
{
    if (User.Goals.Count == 0)
    {
        Console.WriteLine("No goals have been added yet.");
        return;
    }

    Console.WriteLine("Select a goal to record completion for:");
    for (int i = 0; i < User.Goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {User.Goals[i].GetStatus()}");
    }

    Console.Write("Enter the number of the goal: ");
    if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber < 1 || goalNumber > User.Goals.Count)
    {
        Console.WriteLine("Invalid selection. Please try again.");
        return;
    }

    // Adjusting goalNumber to match list indexing (starts from 0)
    goalNumber -= 1;

    User.Goals[goalNumber].RecordEvent();

    Console.WriteLine($"Recorded completion for: {User.Goals[goalNumber].Name}");
}
}