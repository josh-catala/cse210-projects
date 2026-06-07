using System;

class Program
{
    static void Main(string[] args)
    {
        bool using_journal = true;
        Journal my_journal = new Journal();

        while (using_journal == true)
        {
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Load journal");
            Console.WriteLine("4. Save journal");
            // Part of the new method to manage journal prompts.
            Console.WriteLine("5. Manage journal prompts");
            Console.WriteLine("6. Quit");
            int user_input = int.Parse(Console.ReadLine());

            if (user_input == 1)
            {
                my_journal.NewEntry();
            }
            else if (user_input == 2)
            {
                my_journal.Display();
            }
            else if (user_input == 3)
            {
                Console.WriteLine("What is the name of the file?");
                string filename = Console.ReadLine();
                my_journal.LoadJournal(filename);
            }
            else if (user_input == 4)
            {
                Console.WriteLine("What is the name of the file?");
                string filename = Console.ReadLine();
                my_journal.SaveJournal(filename);
            }
            else if (user_input == 5)
            {
                bool manage_prompt = true;
                while (manage_prompt == true)
                {
                    manage_prompt = my_journal.ManagePrompts();
                }
            }
            else if (user_input == 6)
            {
                using_journal = false;
            }
        }
    }
}
