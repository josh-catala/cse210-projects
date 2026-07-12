using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    /// <summary>
    /// Bonus activity added to exceed the core requirements. Guides the
    /// user through a short gratitude journaling exercise, alternating
    /// between a prompt and a quiet moment of reflection with a spinner.
    /// Demonstrates that the base Activity class supports adding new
    /// activity types with no duplicated code.
    /// </summary>
    public class GratitudeActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Name something small that made you smile recently.",
            "Think of a comfort in your life you don't often notice.",
            "Recall a person who has quietly supported you.",
            "Think of a skill or ability you're thankful to have.",
            "Recall a place that brings you a sense of peace."
        };

        private readonly Random _random = new Random();

        public GratitudeActivity() : base(
            "Gratitude",
            "This activity will help you build a habit of gratitude by pausing to " +
            "notice and appreciate the good things already present in your life.")
        {
        }

        protected override void PerformActivity()
        {
            while (!DurationElapsed())
            {
                Console.WriteLine();
                Console.WriteLine(_prompts[_random.Next(_prompts.Count)]);
                ShowSpinner(5);
            }
        }
    }
}
