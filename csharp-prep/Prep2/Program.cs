using System;

class Program
{
    static void Main(string[] args)
    {
        string letterGrade;
        char plus = '+';
        char minus = '-';
        string finalGrade;

        Console.WriteLine("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        // Define Letter Grade.
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }
        
        // Define + or -.
        if (grade % 10 >= 7 && grade < 90)
        {
            finalGrade = letterGrade + plus;
        }
        else if (grade % 10 < 3 && letterGrade != "F")
        {
            finalGrade = letterGrade + minus;
        }
        else
        {
            finalGrade = letterGrade;
        }

        // Display.
        Console.WriteLine($"Your grade is: {finalGrade}");
        if (grade >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You did not pass.");
        }

        
    }
}