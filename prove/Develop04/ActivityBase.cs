

public abstract class ActivityBase
{
    protected string ActivityName { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    protected void StartMessage()
    {
        Console.WriteLine($"Activity: {ActivityName}\nDescription: {Description}\nPlease enter the duration of the activity in seconds:");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(5);
    }

    protected void EndMessage()
    {
        Console.WriteLine("Great job!");
        PauseWithAnimation(2);
        Console.WriteLine($"You have completed the {ActivityName} activity for {Duration} seconds.");
        PauseWithAnimation(2);
    }

    protected void PauseWithAnimation(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // 1 second pause
        }
        Console.WriteLine();
    }

    public abstract void ExecuteActivity();
}