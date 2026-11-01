
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Get numbers from the user
        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Calculate the sum
        int sum = 0;

        foreach (int item in numbers)
        {
            sum += item;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Calculate the average
        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        // Find the largest number
        int largest = numbers[0];

        foreach (int item in numbers)
        {
            if (item > largest)
            {
                largest = item;
            }
        }

        Console.WriteLine($"The largest number is: {largest}");

        // Find the smallest positive number
        int smallestPositive = int.MaxValue;

        foreach (int item in numbers)
        {
            if (item > 0 && item < smallestPositive)
            {
                smallestPositive = item;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        // Sort the list in ascending order
        numbers.Sort();

        Console.WriteLine("The sorted list is:");

        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
