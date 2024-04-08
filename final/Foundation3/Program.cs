using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an event type to create:");
            Console.WriteLine("1. Lecture Event");
            Console.WriteLine("2. Reception Event");
            Console.WriteLine("3. Outdoor Gathering Event");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var lecture = CreateLectureEvent();
                    DisplayEventMarketing(lecture);
                    break;
                case "2":
                    var reception = CreateReceptionEvent();
                    DisplayEventMarketing(reception);
                    break;
                case "3":
                    var outdoor = CreateOutdoorGatheringEvent();
                    DisplayEventMarketing(outdoor);
                    break;
                case "4":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please select a valid option.");
                    break;
            }

            Console.WriteLine(); // Add a blank line for readability
        }
    }

     static LectureEvent CreateLectureEvent()
    {
        Console.Write("Enter Lecture Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Date (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Time: ");
        string time = Console.ReadLine();

        var address = GetAddress();

        Console.Write("Enter Speaker Name: ");
        string speaker = Console.ReadLine();

        Console.Write("Enter Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        return new LectureEvent(title, description, date, time, address, speaker, capacity);
    }

    static ReceptionEvent CreateReceptionEvent()
    {
        Console.Write("Enter Reception Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Date (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Time: ");
        string time = Console.ReadLine();

        var address = GetAddress();

        Console.Write("Enter Email for RSVP: ");
        string emailForRSVP = Console.ReadLine();

        return new ReceptionEvent(title, description, date, time, address, emailForRSVP);
    }

    static OutdoorGatheringEvent CreateOutdoorGatheringEvent()
    {
        Console.Write("Enter Gathering Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Date (MM/DD/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter Time: ");
        string time = Console.ReadLine();

        var address = GetAddress();

        Console.Write("Enter Weather Forecast: ");
        string weather = Console.ReadLine();

        return new OutdoorGatheringEvent(title, description, date, time, address, weather);
    }
static Address GetAddress()
    {
        Console.Write("Enter Street: ");
        string street = Console.ReadLine();

        Console.Write("Enter City: ");
        string city = Console.ReadLine();

        Console.Write("Enter State: ");
        string state = Console.ReadLine();

        Console.Write("Enter Zip Code: ");
        string zipCode = Console.ReadLine();

        return new Address(street, city, state, zipCode);
    }

    static void DisplayEventMarketing(Event eventInstance)
    {
        Console.WriteLine("\nStandard Details:");
        Console.WriteLine(eventInstance.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(eventInstance.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(eventInstance.GetShortDescription());
        Console.WriteLine("-------------------------------------------\n");
    }
}
