
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private List<string> _remainingPrompts;
    private List<string> _gratitudeItems;
    private Random _random;

    public GratitudeActivity()
        : base(
            "Gratitude Activity",
            "This activity will help you develop a positive mindset by recognizing and appreciating the good things in your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "What are three things that made you smile today?",
            "What opportunities are you grateful for?",
            "What is something about yourself that you appreciate?",
            "Who has made a positive difference in your life?",
            "What simple things bring you happiness?"
        };

        _remainingPrompts = new List<string>(_prompts);

        _gratitudeItems = new List<string>();
    }

    private string GetRandomPrompt()
    {
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_remainingPrompts.Count);

        string prompt = _remainingPrompts[index];

        _remainingPrompts.RemoveAt(index);

        return prompt;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Think about the following question:");

        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("Get ready to begin:");

        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Write down the things you appreciate.");
        Console.WriteLine("Press Enter after each response.");

        _gratitudeItems.Clear();

        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("> ");

            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                _gratitudeItems.Add(item.Trim());
            }
        }

        stopwatch.Stop();

        Console.WriteLine();
        Console.WriteLine(
            $"Wonderful! You identified {_gratitudeItems.Count} things to be grateful for.");

        DisplayEndingMessage();
    }
}
