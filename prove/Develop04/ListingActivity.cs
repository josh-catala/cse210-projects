using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    /// <summary>
    /// Guides the user to list as many items as they can related to a
    /// random prompt, within the time limit.
    /// </summary>
    public class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private readonly Random _random = new Random();

        public ListingActivity() : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by " +
            "having you list as many things as you can in a certain area.")
        {
        }

        protected override void PerformActivity()
        {
            Console.WriteLine();
            Console.WriteLine(_prompts[_random.Next(_prompts.Count)]);
            Console.WriteLine();
            Console.WriteLine("You will have a few seconds to think, then start listing items.");
            ShowCountDown(5);

            Console.WriteLine();
            Console.WriteLine("Start listing items (press enter after each one):");

            List<string> items = new List<string>();
            while (!DurationElapsed())
            {
                Console.Write("> ");
                string? item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item.Trim());
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items!");
        }
    }
}
