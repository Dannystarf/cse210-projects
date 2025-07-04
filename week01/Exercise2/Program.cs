using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string gradeLetter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }

        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }

        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
        }

        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
        }

        else
        {
            gradeLetter = "F";
        }
        
        int remainder = gradePercentage % 10;

        if (remainder >= 7)
        {
            sign = "+";
        }
        else if (remainder < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        if (gradePercentage >= 90 && remainder >= 7)
        {
            sign = "";
        }

        if (gradePercentage < 60)
        {
            sign = "";
        }

        Console.WriteLine($"You Grade is {gradeLetter}{sign}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry You did not pass the class. Try again next time!");
        }

    }
}