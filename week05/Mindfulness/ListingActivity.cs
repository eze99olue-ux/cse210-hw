
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _remainingPrompts;
    private List<string> _items;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are some things you are grateful for?"
        };

        _remainingPrompts = new List<string>(_prompts);

        _items = new List<string>();
    }

    // Randomly selects a prompt without repetition until all are used.
    private string GetRandomPrompt()
    {
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_remainingPrompts.Count);

        string selectedPrompt = _remainingPrompts[index];

        _remainingPrompts.RemoveAt(index);

        return selectedPrompt;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");

        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("You may begin in:");

        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Start listing your responses below.");
        Console.WriteLine("Press Enter after each item.");

        _items.Clear();

        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("> ");

            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                _items.Add(item.Trim());
            }
        }

        stopwatch.Stop();

        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items!");

        DisplayEndingMessage();
    }
}
