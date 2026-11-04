
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    // Stores all journal entries
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Adds an entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Displays all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is currently empty.");
            return;
        }

        Console.WriteLine("\n========== YOUR JOURNAL ==========\n");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        Console.WriteLine($"Total Entries: {_entries.Count}");
    }

    // Saves the journal to a JSON file
    public void SaveToFile(string filename)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_entries, options);

        File.WriteAllText(filename, json);

        Console.WriteLine(
            $"\nJournal successfully saved to {filename}"
        );
    }

    // Loads a journal from a JSON file
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException(
                "The specified journal file does not exist."
            );
        }

        string json = File.ReadAllText(filename);

        List<Entry> loadedEntries =
            JsonSerializer.Deserialize<List<Entry>>(json)
            ?? new List<Entry>();

        // Replace existing entries with loaded entries
        _entries.Clear();
        _entries.AddRange(loadedEntries);

        Console.WriteLine(
            $"\nSuccessfully loaded {_entries.Count} journal entries."
        );
    }

    // Returns the number of journal entries
    public int GetEntryCount()
    {
        return _entries.Count;
    }
}
