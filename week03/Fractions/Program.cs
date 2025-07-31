using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Fraction Class Demonstration ===\n");

        // Test all three constructors
        Console.WriteLine("Testing Constructors:");

        // Constructor with no parameters (1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"No parameters: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");

        // Constructor with one parameter (6/1)
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine($"One parameter (6): {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");

        // Constructor with two parameters (6/7)
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine($"Two parameters (6, 7): {fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");

        Console.WriteLine("\n" + new string('-', 40) + "\n");

        // Test getters and setters
        Console.WriteLine("Testing Getters and Setters:");

        Fraction testFraction = new Fraction();
        Console.WriteLine($"Initial fraction: {testFraction.GetFractionString()}");
        Console.WriteLine($"Top: {testFraction.GetTop()}, Bottom: {testFraction.GetBottom()}");

        // Change values using setters
        testFraction.SetTop(3);
        testFraction.SetBottom(4);
        Console.WriteLine($"After setting top=3, bottom=4: {testFraction.GetFractionString()}");
        Console.WriteLine($"New Top: {testFraction.GetTop()}, New Bottom: {testFraction.GetBottom()}");

        Console.WriteLine("\n" + new string('-', 40) + "\n");

        // Test different representations with various fractions
        Console.WriteLine("Testing Different Fraction Representations:");

        // Test 1/5
        Fraction frac1 = new Fraction(1, 5);
        Console.WriteLine($"Fraction: {frac1.GetFractionString()}");
        Console.WriteLine($"Decimal: {frac1.GetDecimalValue():F4}");
        Console.WriteLine();

        // Test 5/3
        Fraction frac2 = new Fraction(5, 3);
        Console.WriteLine($"Fraction: {frac2.GetFractionString()}");
        Console.WriteLine($"Decimal: {frac2.GetDecimalValue():F4}");
        Console.WriteLine();

        // Test 4/1
        Fraction frac3 = new Fraction(4, 1);
        Console.WriteLine($"Fraction: {frac3.GetFractionString()}");
        Console.WriteLine($"Decimal: {frac3.GetDecimalValue():F4}");
        Console.WriteLine();

        // Test 1/3
        Fraction frac4 = new Fraction(1, 3);
        Console.WriteLine($"Fraction: {frac4.GetFractionString()}");
        Console.WriteLine($"Decimal: {frac4.GetDecimalValue():F6}");
        Console.WriteLine();

        Console.WriteLine("=== End of Demonstration ===");
    }
}
