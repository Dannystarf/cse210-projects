using System;
using System.Collections.Generic;
using System.Linq;

namespace Journal
{
    /// <summary>
    /// Manages the collection of journal entries and provides journal operations
    /// </summary>
    public class JournalManager
    {
        private List<Entry> _entries;
        private PromptGenerator _promptGenerator;
        private FileManager _fileManager;

        public JournalManager()
        {
            _entries = new List<Entry>();
            _promptGenerator = new PromptGenerator();
            _fileManager = new FileManager();
        }

        public void AddEntry()
        {
            Console.WriteLine("\n--- New Journal Entry ---");
            string prompt = _promptGenerator.GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("\nYour response: ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                // Ask for mood (creative enhancement)
                Console.Write("How are you feeling? (optional): ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry(prompt, response, mood);
                _entries.Add(newEntry);
                Console.WriteLine("\nEntry saved successfully!");
                Console.WriteLine($"Word count: {newEntry.WordCount}");
            }
            else
            {
                Console.WriteLine("Entry cancelled - no response provided.");
            }
        }

        public void DisplayJournal()
        {
            Console.WriteLine("\n--- Journal Entries ---");

            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries found. Start writing to see your entries here!");
                return;
            }

            Console.WriteLine($"Total entries: {_entries.Count}");
            Console.WriteLine($"Total words written: {_entries.Sum(e => e.WordCount)}");
            Console.WriteLine(new string('-', 50));

            for (int i = 0; i < _entries.Count; i++)
            {
                Console.WriteLine($"Entry #{i + 1}:");
                Console.WriteLine(_entries[i].ToString());
                Console.WriteLine(new string('-', 50));
            }
        }

        public void SaveToFile()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to save.");
                return;
            }

            Console.Write("Enter filename to save to: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            // Add .txt extension if not provided
            if (!filename.Contains("."))
            {
                filename += ".txt";
            }

            if (_fileManager.SaveJournal(_entries, filename))
            {
                Console.WriteLine($"Journal saved successfully to {filename}");
                Console.WriteLine($"Saved {_entries.Count} entries.");
            }
        }

        public void LoadFromFile()
        {
            Console.Write("Enter filename to load from: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            // Add .txt extension if not provided
            if (!filename.Contains("."))
            {
                filename += ".txt";
            }

            if (_entries.Count > 0)
            {
                Console.Write("This will replace your current entries. Continue? (y/n): ");
                string confirm = Console.ReadLine()?.ToLower();
                if (confirm != "y" && confirm != "yes")
                {
                    Console.WriteLine("Load cancelled.");
                    return;
                }
            }

            List<Entry> loadedEntries = _fileManager.LoadJournal(filename);

            if (loadedEntries.Count > 0)
            {
                _entries = loadedEntries;
                Console.WriteLine($"Successfully loaded {_entries.Count} entries from {filename}");
            }
            else
            {
                Console.WriteLine("No entries were loaded.");
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\n--- Journal Statistics ---");

            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to analyze.");
                return;
            }

            Console.WriteLine($"Total entries: {_entries.Count}");
            Console.WriteLine($"Total words: {_entries.Sum(e => e.WordCount)}");
            Console.WriteLine($"Average words per entry: {_entries.Average(e => e.WordCount):F1}");

            var entriesWithMood = _entries.Where(e => !string.IsNullOrEmpty(e.Mood)).ToList();
            if (entriesWithMood.Count > 0)
            {
                Console.WriteLine($"Entries with mood recorded: {entriesWithMood.Count}");
                var moodGroups = entriesWithMood.GroupBy(e => e.Mood.ToLower())
                    .OrderByDescending(g => g.Count());
                Console.WriteLine("Most common moods:");
                foreach (var group in moodGroups.Take(3))
                {
                    Console.WriteLine($"  {group.Key}: {group.Count()} times");
                }
            }

            if (_entries.Count > 0)
            {
                var oldestEntry = _entries.OrderBy(e => e.Date).First();
                var newestEntry = _entries.OrderByDescending(e => e.Date).First();
                Console.WriteLine($"First entry: {oldestEntry.Date}");
                Console.WriteLine($"Latest entry: {newestEntry.Date}");
            }
        }

        public void AddCustomPrompt()
        {
            Console.Write("Enter your custom prompt: ");
            string customPrompt = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(customPrompt))
            {
                _promptGenerator.AddCustomPrompt(customPrompt);
                Console.WriteLine("Custom prompt added successfully!");
                Console.WriteLine($"Total prompts available: {_promptGenerator.PromptCount}");
            }
            else
            {
                Console.WriteLine("Invalid prompt.");
            }
        }

        public int EntryCount => _entries.Count;
    }
}
