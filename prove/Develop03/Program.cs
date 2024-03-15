class Program
{
    static void Main(string[] args)
    {
        //instructions
        Console.WriteLine("Scripture memorization program");
        Console.WriteLine("Type in a scripture reference and the text, and I will hide words when you push enter to help you memorize it.");

        //prompt user for a scripture reference, store and stringify it
        Console.WriteLine("Enter the scripture reference:");
        string reference = Console.ReadLine();
        
        //prompt user for the text to that reference, store and stringify it
        Console.WriteLine("Enter the text to that scripture:");
        string text = Console.ReadLine();
        
        //convert to list and hash
        List<string> scripture = text.Split(' ').ToList();
        HashSet<int> hiddenWords = new HashSet<int>();
        //pick random words
        Random rand = new Random();

        //cLear the console and display the scripture to the user
        DisplayScripture(reference, scripture, hiddenWords);
        
        //while loop that will pick random words to hide
        while (true)
        {
            //give user instructions 
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string userInput = Console.ReadLine();
            //type quit to break the loop
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            //count hidden words loop will run 
            if (hiddenWords.Count < scripture.Count)
            {
                int indexToHide;
                do
                {
                    indexToHide = rand.Next(scripture.Count);
                } while (hiddenWords.Contains(indexToHide));
                
                hiddenWords.Add(indexToHide);
                DisplayScripture(reference, scripture, hiddenWords);
            }
            //else statement for when all words are hidden, break the loop
            else
            {
                Console.WriteLine("There are no more words in the scripture to delete. Exiting program now.");
                break;
            }
        }
    }

    static void DisplayScripture(string reference, List<string> words, HashSet<int> hiddenWords)
    {
        Console.Clear();
        Console.WriteLine(reference);
        //for loop will count words
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenWords.Contains(i))
            {
                //hidden word place holder
                Console.Write("____ ");
            }
            else
            {
                Console.Write(words[i] + " ");
            }
        }
        //write new line each time
        Console.WriteLine("\n");
    }
}