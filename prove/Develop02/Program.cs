using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<JournalEntry>();
        prompts = new List<string>
        {
           "I was today years old when I found out....",
            "If I could redo something today what would it be?",
            "What are three things you are grateful for today?",
            "Do I have any goals that I'm working on? If so, what did I do to get closer to achieving them? If not, try making one.",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "What was the most memorable part of my day?",
            "My guilty pleasure of the day?",
            "What can I do to make tomorrow better?",
            "Did you give your 100% today of what you could give?",
            "What was today's weather? How did it make me feel?",
            "Best thing I ate today?"
        };
    }

    public void AddEntry()
    {
        Random rnd = new Random();
        int index = rnd.Next(prompts.Count);
        Console.WriteLine(prompts[index]);
        string response = Console.ReadLine();
        JournalEntry entry = new JournalEntry(prompts[index], response);
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter filename to save:");
        string filename = Console.ReadLine();
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter filename to load:");
        string filename = Console.ReadLine();
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                JournalEntry entry = new JournalEntry(parts[1], parts[2])
                {
                    Date = DateTime.Parse(parts[0])
                };
                entries.Add(entry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournal();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
