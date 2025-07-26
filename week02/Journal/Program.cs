using System;

namespace Journal
{
    /// <summary>
    /// Main program class for the Journal application
    /// 
    /// CREATIVITY AND EXCEEDING REQUIREMENTS:
    /// 1. Added mood tracking for each entry to help users reflect on emotional patterns
    /// 2. Implemented word counting to encourage writing and track progress
    /// 3. Added comprehensive statistics feature showing writing patterns and mood analysis
    /// 4. Created custom prompt functionality allowing users to add their own prompts
    /// 5. Enhanced user interface with better formatting and confirmation dialogs
    /// 6. Added input validation and error handling throughout the application
    /// 7. Implemented automatic file extension handling for user convenience
    /// 8. Added entry numbering and total counts for better organization
    /// 9. Created a more robust file format that handles multiple data fields
    /// 10. Added confirmation dialogs for destructive operations (like loading over existing entries)
    /// 
    /// These enhancements address several barriers to journaling:
    /// - Mood tracking helps users see emotional patterns over time
    /// - Statistics provide motivation by showing progress
    /// - Custom prompts solve the "don't know what to write" problem
    /// - Word counting gamifies the experience
    /// - Better UX makes the app more pleasant to use consistently
    /// </summary>
    class Program
    {
        private static JournalManager _journalManager;

        static void Main(string[] args)
        {
            _journalManager = new JournalManager();

            Console.WriteLine("Welcome to your Personal Journal!");
            Console.WriteLine("This app helps you reflect on your daily experiences.");

            bool running = true;
            while (running)
            {
                running = ShowMenuAndProcessChoice();
            }

            Console.WriteLine("Thank you for using your Personal Journal. Keep writing!");
        }

        static bool ShowMenuAndProcessChoice()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("PERSONAL JOURNAL MENU");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Show journal statistics");
            Console.WriteLine("6. Add custom prompt");
            Console.WriteLine("7. Quit");
            Console.Write("\nWhat would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _journalManager.AddEntry();
                    break;
                case "2":
                    _journalManager.DisplayJournal();
                    break;
                case "3":
                    _journalManager.SaveToFile();
                    break;
                case "4":
                    _journalManager.LoadFromFile();
                    break;
                case "5":
                    _journalManager.ShowStatistics();
                    break;
                case "6":
                    _journalManager.AddCustomPrompt();
                    break;
                case "7":
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-7.");
                    break;
            }

            // Pause before showing menu again
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return true;
        }
    }
}
