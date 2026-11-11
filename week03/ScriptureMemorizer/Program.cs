
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // CREATIVITY AND EXCEEDING REQUIREMENTS:
        // Instead of using only one scripture, this program contains
        // a library of three scriptures and randomly selects one each
        // time the application starts.
        //
        // It also hides three words at a time, selects only words
        // that have not already been hidden, and displays a progress
        // indicator showing how many words remain visible.

        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            )
        };

        // Randomly select a scripture from the library.
        Random random = new Random();

        int randomIndex = random.Next(scriptureLibrary.Count);

        Scripture selectedScripture = scriptureLibrary[randomIndex];

        Console.WriteLine("====================================");
        Console.WriteLine("       SCRIPTURE MEMORIZER");
        Console.WriteLine("====================================");
        Console.WriteLine();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Memorize the scripture by hiding words.");
        Console.WriteLine("Three words will be hidden each time.");
        Console.WriteLine();

        Console.WriteLine("Press ENTER to begin.");
        Console.ReadLine();

        // Continue until the user quits or all words are hidden.
        while (true)
        {
            Console.Clear();

            selectedScripture.Display();

            int remainingWords =
                selectedScripture.GetRemainingWordCount();

            int totalWords =
                selectedScripture.GetTotalWordCount();

            Console.WriteLine("------------------------------------");
            Console.WriteLine(
                $"Words remaining: {remainingWords} out of {totalWords}"
            );
            Console.WriteLine("------------------------------------");

            // End the program when every word is hidden.
            if (selectedScripture.AllWordsHidden())
            {
                Console.WriteLine();
                Console.WriteLine("Congratulations!");
                Console.WriteLine("You have hidden all the words.");
                Console.WriteLine("Keep practising until you memorize it!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press ENTER to hide more words or type 'quit' to exit: ");

            string userInput = Console.ReadLine() ?? "";

            // Allow the user to quit at any time.
            if (userInput.Trim().Equals(
                "quit",
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using Scripture Memorizer!");
                break;
            }

            // Hide three randomly selected visible words.
            selectedScripture.HideRandomWords(3);
        }
    }
}
