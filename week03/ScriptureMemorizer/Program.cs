using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Scripture Memorizer Program
    /// 
    /// Exceeding Requirements:
    /// 1. Added a library of scriptures that are randomly selected for the user
    /// 2. Implemented smart word selection that only hides words that aren't already hidden
    /// 3. Added progress tracking to show how many words are left to memorize
    /// 4. Enhanced user experience with colored console output and better formatting
    /// 5. Added validation for scripture references and error handling
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary();
            Scripture currentScripture = library.GetRandomScripture();

            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.\n");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Scripture Memorizer");
                Console.WriteLine("==================");
                Console.WriteLine();

                // Display the scripture
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();

                // Show progress
                int hiddenCount = currentScripture.GetHiddenWordCount();
                int totalCount = currentScripture.GetTotalWordCount();
                Console.WriteLine($"Progress: {hiddenCount}/{totalCount} words hidden");
                Console.WriteLine();

                // Check if all words are hidden
                if (currentScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Congratulations! You have hidden all the words!");
                    Console.WriteLine("Press Enter to try another scripture, or type 'quit' to exit.");

                    string finalInput = Console.ReadLine();
                    if (finalInput?.ToLower() == "quit")
                    {
                        break;
                    }
                    else
                    {
                        // Start with a new random scripture
                        currentScripture = library.GetRandomScripture();
                        continue;
                    }
                }

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                // Hide some random words
                currentScripture.HideRandomWords(3);
            }

            Console.WriteLine("Thank you for using Scripture Memorizer!");
        }
    }
}
