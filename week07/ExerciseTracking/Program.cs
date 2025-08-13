using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold different types of activities
        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 25, 20));

        // Add additional activities to demonstrate variety
        activities.Add(new Running(new DateTime(2022, 11, 4), 25, 2.5));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 60, 12.5));
        activities.Add(new Swimming(new DateTime(2022, 11, 4), 30, 25));

        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("=========================");

        // Iterate through the list and display summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
