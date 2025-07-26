using System;

namespace Journal
{
    /// <summary>
    /// Represents a single journal entry with a prompt, response, date, and mood
    /// </summary>
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }
        public string Mood { get; set; }
        public int WordCount { get; private set; }

        public Entry(string prompt, string response, string mood = "")
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Mood = mood;
            WordCount = CalculateWordCount(response);
        }

        // Constructor for loading from file
        public Entry(string prompt, string response, string date, string mood = "")
        {
            Prompt = prompt;
            Response = response;
            Date = date;
            Mood = mood;
            WordCount = CalculateWordCount(response);
        }

        private int CalculateWordCount(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public override string ToString()
        {
            string moodDisplay = string.IsNullOrEmpty(Mood) ? "" : $" | Mood: {Mood}";
            return $"Date: {Date}{moodDisplay} | Words: {WordCount}\n" +
                   $"Prompt: {Prompt}\n" +
                   $"Response: {Response}\n";
        }

        public string ToFileString()
        {
            return $"{Date}~|~{Prompt}~|~{Response}~|~{Mood}";
        }
    }
}
