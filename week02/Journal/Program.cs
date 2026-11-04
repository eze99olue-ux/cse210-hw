
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create the journal and prompt generator objects
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        Console.WriteLine("========================================");
        Console.WriteLine("           MY PERSONAL JOURNAL");
        Console.WriteLine("========================================");
        Console.WriteLine("A place to record your thoughts and experiences.");
        Console.WriteLine("Your story matters. Write something today!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");

            Console.Write("\nWhat would you like to do? ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    // Generate a random writing prompt
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine("\nToday's journal prompt:");
                    Console.WriteLine(prompt);

                    // Get the user's response
                    Console.Write("\nYour response: ");
                    string response = Console.ReadLine() ?? "";

                    while (string.IsNullOrWhiteSpace(response))
                    {
                        Console.Write("Response cannot be empty. Try again: ");
                        response = Console.ReadLine() ?? "";
                    }

                    // Ask the user about their mood
                    Console.Write(
                        "\nHow are you feeling today? "
                    );

                    string mood = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(mood))
                    {
                        mood = "Not specified";
                    }

                    // Automatically get the current date
                    string date = DateTime.Now.ToString("dd MMMM yyyy");

                    // Create a new journal entry
                    Entry newEntry = new Entry(
                        date,
                        prompt,
                        response,
                        mood
                    );

                    // Add the entry to the journal
                    myJournal.AddEntry(newEntry);

                    Console.WriteLine(
                        "\nYour journal entry has been added successfully!"
                    );

                    break;

                case "2":
                    // Display all journal entries
                    myJournal.DisplayAll();
                    break;

                case "3":
                    // Save journal to a file
                    Console.Write(
                        "\nEnter the filename to save your journal: "
                    );

                    string saveFilename = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(saveFilename))
                    {
                        Console.WriteLine("Filename cannot be empty.");
                        break;
                    }

                    try
                    {
                        myJournal.SaveToFile(saveFilename);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            $"Error saving journal: {ex.Message}"
                        );
                    }

                    break;

                case "4":
                    // Load journal from a file
                    Console.Write(
                        "\nEnter the filename to load your journal: "
                    );

                    string loadFilename = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(loadFilename))
                    {
                        Console.WriteLine("Filename cannot be empty.");
                        break;
                    }

                    try
                    {
                        myJournal.LoadFromFile(loadFilename);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            $"Error loading journal: {ex.Message}"
                        );
                    }

                    break;

                case "5":
                    Console.WriteLine("\nThank you for using My Personal Journal!");
                    Console.WriteLine("Keep writing. Every day matters.");

                    running = false;
                    break;

                default:
                    Console.WriteLine(
                        "\nInvalid choice. Please select a number from 1 to 5."
                    );

                    break;
            }
        }
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:

1. Mood Tracking:
   Users can record their emotional state alongside each entry.

2. Automatic Word Count:
   The program calculates and displays the number of words
   written in each journal response.

3. More Writing Prompts:
   The program contains 12 different prompts instead of
   the minimum five required.

4. JSON File Storage:
   The program uses JSON serialization to save and load
   journal entries. This preserves commas, quotation marks
   and other special characters in users' responses.

5. Input Validation:
   The program prevents users from saving empty journal
   responses or submitting empty filenames.

6. Error Handling:
   The program handles file-related errors without
   unexpectedly terminating the application.

These additional features make the journal more useful,
reliable and user-friendly.
*/
