

public class BreathingActivity : ActivityBase
{
    public BreathingActivity()
    {
        ActivityName = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void ExecuteActivity()
    {
        StartMessage();

        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine("Breathe in...");
            // expanding circle
            ExpandCircle();
            elapsedTime += 4;

            if (elapsedTime < Duration)
            {
                Console.WriteLine("Breathe out...");
                // contracting circle
                ContractCircle();
                elapsedTime += 4;
            }
        }

        EndMessage();
    }

    private void ExpandCircle()
    {
        for (int i = 0; i < 5; i++) // Simulate expanding
        {
            Console.Clear();
            Console.WriteLine(new string('o', i * 2)); // This is a very rudimentary representation
            Thread.Sleep(800); // Adjust timing as needed
        }
    }

    private void ContractCircle()
    {
        for (int i = 5; i > 0; i--) // Simulate contracting
        {
            Console.Clear();
            Console.WriteLine(new string('o', i * 2)); // This is a very rudimentary representation
            Thread.Sleep(800); // Adjust timing as needed
        }
    }
}