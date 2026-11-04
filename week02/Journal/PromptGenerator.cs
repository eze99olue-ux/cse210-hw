
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What new thing did I learn today?",
            "What is one thing I am grateful for today?",
            "What challenge did I overcome today?",
            "What did I do today that brought me closer to my goals?",
            "What is one thing I want to improve tomorrow?",
            "Who made me smile today, and why?",
            "What small achievement am I proud of today?"
        };
    }

    // Selects and returns a random prompt
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);

        return _prompts[index];
    }
}
