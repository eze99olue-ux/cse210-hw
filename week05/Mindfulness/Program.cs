
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        // Tracks the number of times each activity is completed.
        Dictionary<string, int> activityCounts =
            new Dictionary<string, int>
            {
                { "Breathing Activity", 0 },
                { "Reflection Activity", 0 },
                { "Listing Activity", 0 },
                { "Gratitude Activity", 0 }
            };

        int totalActivities = 0;
        int totalMindfulnessSeconds = 0;

        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Take a moment to relax, reflect, and grow.");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;

                case "2":
                    activity = new ReflectionActivity();
                    break;

                case "3":
                    activity = new ListingActivity();
                    break;

                case "4":
                    activity = new GratitudeActivity();
                    break;

                case "5":
                    running = false;
                    continue;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection. Please choose 1-5.");
                    continue;
            }

            // Run the selected activity using inheritance and polymorphism.
            activity.Run();

            // Update session statistics after successful completion.
            activityCounts[activity.ActivityName]++;

            totalActivities++;

            totalMindfulnessSeconds += activity.Duration;

            Console.WriteLine();
            Console.WriteLine("Returning to the main menu...");

            activity = null;

            System.Threading.Thread.Sleep(1500);
        }

        // Display a session summary before exiting.
        Console.Clear();

        Console.WriteLine("==================================");
        Console.WriteLine("       MINDFULNESS SUMMARY");
        Console.WriteLine("==================================");

        Console.WriteLine();
        Console.WriteLine($"Total activities completed: {totalActivities}");

        Console.WriteLine();
        Console.WriteLine("Activity Breakdown:");

        foreach (var activity in activityCounts)
        {
            Console.WriteLine($"{activity.Key}: {activity.Value} time(s)");
        }

        int minutes = totalMindfulnessSeconds / 60;
        int seconds = totalMindfulnessSeconds % 60;

        Console.WriteLine();
        Console.WriteLine(
            $"Total mindfulness time: {minutes} minute(s) and {seconds} second(s)");

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine("Remember to take time for yourself every day.");

        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS

This program exceeds the core requirements in the following ways:

1. Additional Activity:
   I created a fourth activity called GratitudeActivity.
   It encourages users to recognize and appreciate positive things
   in their lives.

2. Random Prompts Without Repetition:
   Reflection, Listing, and Gratitude activities use collections
   of prompts. A selected prompt is removed from the available
   collection until all prompts have been used. The collection
   is then replenished.

   Reflection questions also avoid repetition until all questions
   have been used.

3. Session Statistics:
   The program tracks how many times each activity is completed
   during the current session.

4. Session Summary:
   When the user exits, the program displays the total activities
   completed, the breakdown by activity, and the total mindfulness
   time.

5. Input Validation:
   The program checks that activity durations are positive numbers
   and that menu selections are valid.

6. Animations:
   The base Activity class provides reusable spinner and countdown
   animations using Thread.Sleep() and backspace characters.

These additions improve the usefulness of the application while
demonstrating inheritance, encapsulation, abstraction, and
polymorphism.
*/
