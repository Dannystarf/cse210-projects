using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    /// <summary>
    /// Handles file operations for saving and loading journal entries
    /// </summary>
    public class FileManager
    {
        public bool SaveJournal(List<Entry> entries, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in entries)
                    {
                        writer.WriteLine(entry.ToFileString());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                return false;
            }
        }

        public List<Entry> LoadJournal(string filename)
        {
            List<Entry> entries = new List<Entry>();

            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    return entries;
                }

                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = ParseEntryFromLine(line);
                        if (entry != null)
                        {
                            entries.Add(entry);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }

            return entries;
        }

        private Entry ParseEntryFromLine(string line)
        {
            try
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);

                if (parts.Length >= 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    string mood = parts.Length > 3 ? parts[3] : "";

                    return new Entry(prompt, response, date, mood);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing entry: {ex.Message}");
            }

            return null;
        }

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
