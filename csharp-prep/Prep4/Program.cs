using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        bool loop = true;
        
        while (loop == true)
        {
           Console.WriteLine("Enter a number (either positive or negative): ");
           int response = int.Parse(Console.ReadLine());
           if(response == 0){loop = false;}
           else{numbers.Add(response);}
        }

        
        int sum = 0;
        int largest = 0;
        int smallest_pos = int.MaxValue;
        
        foreach (int number in numbers)
        {   
            sum += number;
            if (number > largest)
            {
                largest = number;
            }

            if (number > 0 && number < smallest_pos)
            {
                smallest_pos = number;
            }

            
        }
        // Sum.
        Console.WriteLine($"The sum is: {sum}");
        
        // Average.
        float avg = sum / numbers.Count;
        Console.WriteLine($"The average is: {avg}");

        // Largest.
        Console.WriteLine($"The largest number is: {largest}");

        // Smallest positive.
        Console.WriteLine($"The smallest positive number is: {smallest_pos}");

        // Sorted list. 
        List<int> sorted_numbers = numbers;
        sorted_numbers.Sort();
        string result = string.Join(", ", sorted_numbers); 
        Console.WriteLine($"The sorted list is: {result}");
        
    }
}