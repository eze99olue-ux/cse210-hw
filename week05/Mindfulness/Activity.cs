
using System;
using System.Threading;

public abstract class Activity
{
    // Private member variables shared by all activities.
    private string _activityName;
    private string _description;
    private int _duration;

    // Public properties allow controlled access to shared information.
    public string ActivityName
    {
        get { return _activityName; }
    }

    public int Duration
    {
        get { return _duration; }
    }

    // Constructor initializes the activity information.
    protected Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
        _duration = 0;
    }

    // Common starting message used by all activities.
    protected void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = GetValidDuration();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
    }

    // Validates the duration entered by the user.
    private int GetValidDuration()
    {
        int duration;

        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    // Common ending message used by all activities.
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!! You have done a great job!");

        PauseWithSpinner(2);

        Console.WriteLine();
        Console.WriteLine($"You have completed the {_activityName}.");
        Console.WriteLine($"Duration: {_duration} seconds.");

        PauseWithSpinner(3);
    }

    // Spinner animation using backspace characters.
    protected void ShowSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index = (index + 1) % animation.Length;
        }
    }

    // Pauses while displaying a spinner.
    protected void PauseWithSpinner(int seconds)
    {
        ShowSpinner(seconds);
        Console.WriteLine();
    }

    // Countdown animation shared by the activities.
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Every derived activity must implement its own Run method.
    public abstract void Run();
}
