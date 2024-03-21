

public class ListingActivity : ActivityBase
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        ActivityName = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void ExecuteActivity()
    {
        StartMessage();

        var random = new Random();
        var prompt = listingPrompts[random.Next(listingPrompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(5);

        Console.WriteLine("Start listing (type 'end' to finish):");
        var items = new List<string>();
        string input;
        var startTime = DateTime.Now;

        do
        {
            input = Console.ReadLine();
            if (input.ToLower() != "end" && !string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }

            if ((DateTime.Now - startTime).TotalSeconds >= Duration)
                break;
        }
        while (input.ToLower() != "end");

        Console.WriteLine($"You've listed {items.Count} items.");
        EndMessage();
    }
}