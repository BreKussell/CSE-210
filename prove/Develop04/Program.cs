using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:\n1. Breathing\n2. Reflection\n3. Listing\n4. Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    var breathingActivity = new BreathingActivity();
                    breathingActivity.ExecuteActivity();
                    break;
                case "2":
                    var reflectionActivity = new ReflectionActivity();
                    reflectionActivity.ExecuteActivity();
                    break;
                case "3":
                    var listingActivity = new ListingActivity();
                    listingActivity.ExecuteActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}