using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public List<string> _prompts = new List<string>
    {
        "How have you seen the Lord's hand?",
        "How was your communication with God?",
        "What was your favorite part of the day?",
        "How do you feel?",
        "Who made an impact in your day?"
    };

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

        foreach (string l in lines)
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
