
using System;

public class Entry
{
    // Private member variables
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    // Public properties
    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string Prompt
    {
        get { return _prompt; }
        set { _prompt = value; }
    }

    public string Response
    {
        get { return _response; }
        set { _response = value; }
    }

    public string Mood
    {
        get { return _mood; }
        set { _mood = value; }
    }

    // Default constructor for JSON loading
    public Entry()
    {
        _date = "";
        _prompt = "";
        _response = "";
        _mood = "";
    }

    // Constructor for creating a new entry
    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    // Displays the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Word Count: {GetWordCount()}");
        Console.WriteLine("----------------------------------------");
    }

    // Counts the words in the response
    public int GetWordCount()
    {
        if (string.IsNullOrWhiteSpace(_response))
        {
            return 0;
        }

        string[] words = _response.Split(
            new char[] { ' ', '\t', '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries
        );

        return words.Length;
    }
}
