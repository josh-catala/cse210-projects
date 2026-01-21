using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string play = "";

        do
        {   
            int magic_num = RandomNumberGenerator.GetInt32(1,10);
            Console.WriteLine("A random number from 1-10 has been generated.");
            bool guessed = false;
            int guess_count = 0;

            while (guessed == false)
                {
                    Console.Write("What is your guess? ");
                    string guess_input = Console.ReadLine();
                    int guess_num = int.Parse(guess_input);
                    guess_count++;

                    if (guess_num == magic_num)
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"Your guess count was: {guess_count}");
                        guessed = true;
                        Console.WriteLine("Would you like to play again (y/n)? ");
                        play = Console.ReadLine();
                    } 
                    else if (guess_num > magic_num)
                    {
                        Console.WriteLine("Lower");
                    }
                    else if (guess_num < magic_num)
                    {
                        Console.WriteLine("Higher");
                    }
                }
        } while (play == "y");
    }
}