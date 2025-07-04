using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to this number guessing game. A magic number has been chosen between 1 and 100. Try to guess it!");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = 0;
        int guessCount = 0;

        do
        {
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);

            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != magicNumber);

        Console.WriteLine($"You made a total of {guessCount} guess(es).");

        Console.WriteLine("");

        Console.Write("Did you want to play again? (yes/n0) ");
        string playAgain = Console.ReadLine().ToLower();

        if (playAgain == "yes")
        {
            Main(args);
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
        
        Console.WriteLine("");
    }
}