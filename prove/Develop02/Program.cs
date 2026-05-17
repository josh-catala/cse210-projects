using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

class Program
{
    public class Entry
    {
        public string _date;
        public string _prompt = "";
        public string _content = "";
    }

    public class Journal
    {     
        public List<Entry> _entries = new List<Entry>();
        public List<string> _prompts = ["How have you seen the Lord's hand?", "How was your communication with God?",
        "What was your favorite part of the day?", "How do you feel?", "Who made an impact in your day?"];

        public void NewEntry()
        {
            Entry entry = new Entry();
            entry._date = DateTime.Today.ToString("yyyy-MM-dd");
            Random random = new Random();
            int random_prompt_index = random.Next(0, _prompts.Count - 1);            
            entry._prompt = _prompts[random_prompt_index];

            Console.WriteLine($"{entry._prompt}");
            entry._content = Console.ReadLine();
            _entries.Add(entry);
        }

        public void Display()
            {

                foreach (Entry e in _entries)
                    {
                        Console.WriteLine($"Date: {e._date} -- Prompt: {e._prompt}");
                        Console.WriteLine($"{e._content}");
                        Console.WriteLine("");
                    }
            }

        public void SaveJournal(string filename)
            {   
                using (StreamWriter output_file = new StreamWriter(filename))
            {
                foreach (Entry e in _entries)
                    {
                        output_file.WriteLine($"{e._date}|{e._prompt}|{e._content}");
                    }
            }
            }
        
        public void LoadJournal(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach(string l in lines)
            {
                string[] line_parts = l.Split('|');
                Entry entry = new Entry();
                entry._date = line_parts[0];
                entry._prompt = line_parts[1];
                entry._content = line_parts[2];
                _entries.Add(entry);
            }
        }
        // Exceeded requirements by creating a new function to manage the prompts used within the journal class.
        public Boolean ManagePrompts()
        {
            Console.WriteLine("");
            Console.WriteLine("These are your saved prompts.");
            Console.WriteLine(string.Join($"\n", _prompts));
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Quit");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
                {
                    AddPrompt();
                    return true;
                }
            else if (input == 2)
                {
                    Console.WriteLine("These is your current prompt list");
                    int count = 1;
                    foreach (string p in _prompts)
                    {
                        Console.WriteLine($"{count}. {p}");
                        count++;
                    }
                    Console.WriteLine("Enter the number of the prompt you would like to delete: ");
                    int prompt_num = int.Parse(Console.ReadLine());
                    DeletePrompt(prompt_num);
                    return true;
                }
            else if (input == 3)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Enter a valid option.");
                return true;
            }
        }

        public void AddPrompt()
            {
                Console.WriteLine("What prompt would you like to add?");
                string prompt = Console.ReadLine();
                _prompts.Add(prompt);
                Console.WriteLine("Prompt added succesfully.");
            }

        public void DeletePrompt(int prompt_num)
            {
                int index = prompt_num - 1;
                _prompts.RemoveAt(index);
                Console.WriteLine("Prompt succesfully deleted.");
            }

    }
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
