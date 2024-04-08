using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        bool addingActivities = true;

        Console.WriteLine("Activity Tracker\n");

        while (addingActivities)
        {
            Console.WriteLine("Select an activity type:");
            Console.WriteLine("1. Running");
            Console.WriteLine("2. Cycling");
            Console.WriteLine("3. Swimming");
            Console.WriteLine("4. Done Adding Activities");
            Console.Write("Enter your choice (1-4): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 4)
            {
                addingActivities = false;
                break;
            }

            Console.Write("Enter date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Enter duration in minutes: ");
            int duration = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter distance in km: ");
                    double runningDistance = double.Parse(Console.ReadLine());
                    activities.Add(new Running(date, duration, runningDistance));
                    Console.WriteLine("Running activity added.\n");
                    break;

                case 2:
                    Console.Write("Enter speed in km/h: ");
                    double cyclingSpeed = double.Parse(Console.ReadLine());
                    activities.Add(new Cycling(date, duration, cyclingSpeed));
                    Console.WriteLine("Cycling activity added.\n");
                    break;

                case 3:
                    Console.Write("Enter number of laps: ");
                    int swimmingLaps = int.Parse(Console.ReadLine());
                    activities.Add(new Swimming(date, duration, swimmingLaps));
                    Console.WriteLine("Swimming activity added.\n");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    break;
            }
        }

        Console.WriteLine("Summary of Activities:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}