using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter a number: ");
        string userInput = Console.ReadLine();
        int numbers = int.Parse(userInput);

        List<int> numberList = new List<int>();
        while (numbers != 0)
        {
            numberList.Add(numbers);
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();
            numbers = int.Parse(userInput);
        }

        int sum = numberList.Sum();
        double average = numberList.Average();
        int largest = numberList.Max();
        int smallestPositive = 0;
        string noPositiveNumbers = "There are no positive numbers in the list.";

        List<int> positiveNumbers = numberList.Where(n => n > 0).ToList();

        Console.WriteLine();
        Console.WriteLine($"The sum is : {sum}");
        Console.WriteLine($"The average is : {average}");
        Console.WriteLine($"The largest number is : {largest}");

        if (positiveNumbers.Any())
        {
            smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest postive number is : {smallestPositive}");
        }
        else
        {
            Console.WriteLine($"The smallest postive number is : {noPositiveNumbers}");
        }

        Console.WriteLine("The sorted list is : ");
        Console.WriteLine();

        List<int> sortedAscending = numberList.OrderBy(n => n).ToList();

        foreach (int num in sortedAscending)
        {
            Console.WriteLine(num);
        }

    }
}