using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int fav_num = int.Parse(Console.ReadLine());
            return fav_num;
        }

        static void PromptUserBirthYear(out int birth_year)
        {
            Console.Write("Please enter the year you were born: ");
            birth_year = int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int fav_num)
        {
            int square_num = fav_num * fav_num;
            return square_num;
        }

        static void DisplayResult(string username, int square_num, int birth_year)
        {
            Console.WriteLine($"{username}, the square of your number is {square_num}.");

            int current_year = DateTime.Now.Year;
            int age = current_year - birth_year;
            Console.WriteLine($"{username} you will turn {age} this year.");
        }


        static void Main()
        {
            DisplayWelcome();
            string username = PromptUserName();
            int fav_num = PromptUserNumber();
            PromptUserBirthYear(out int birth_year);
            int square_num = SquareNumber(fav_num);
            DisplayResult(username, square_num, birth_year);
        }

        Main();
    }
}