
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _remainingPrompts;

    private List<string> _questions;
    private List<string> _remainingQuestions;

    private Random _random;

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a personal challenge."
        };

        _remainingPrompts = new List<string>(_prompts);

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _remainingQuestions = new List<string>(_questions);
    }

    // Selects a random prompt without repeating until all are used.
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

    // Selects a random question without repeating until all are used.
    private string GetRandomQuestion()
    {
        if (_remainingQuestions.Count == 0)
        {
            _remainingQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_remainingQuestions.Count);

        string selectedQuestion = _remainingQuestions[index];

        _remainingQuestions.RemoveAt(index);

        return selectedQuestion;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");

        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");

        Console.ReadLine();

        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());

            int remaining = Duration -
                (int)Math.Floor(stopwatch.Elapsed.TotalSeconds);

            int pauseDuration = Math.Min(5, remaining);

            Console.WriteLine();
            Console.Write("Reflect on this question ");

            PauseWithSpinner(pauseDuration);
        }

        stopwatch.Stop();

        DisplayEndingMessage();
    }
}
