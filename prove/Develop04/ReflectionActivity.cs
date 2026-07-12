using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    /// <summary>
    /// Guides the user to reflect deeply on a meaningful experience by
    /// showing a random prompt followed by a series of random follow-up
    /// questions.
    /// Exceeds requirements: questions are shuffled and drawn without
    /// repeats until the whole list has been used once, so the user
    /// doesn't see the same question twice in a row or too soon.
    /// </summary>
    public class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private List<string> _remainingQuestions = new List<string>();
        private readonly Random _random = new Random();

        public ReflectionActivity() : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have " +
            "shown strength and resilience. This will help you recognize the power you " +
            "have and how you can use it in other aspects of your life.")
        {
        }

        protected override void PerformActivity()
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomItem(_prompts));
            Console.WriteLine();

            _remainingQuestions = new List<string>(_questions);

            while (!DurationElapsed())
            {
                Console.WriteLine();
                Console.Write(GetNextQuestion());
                Console.WriteLine();
                ShowSpinner(4);
            }
        }

        /// <summary>
        /// Pulls a question without repeating any question until the full
        /// list has been exhausted, then reshuffles.
        /// </summary>
        private string GetNextQuestion()
        {
            if (_remainingQuestions.Count == 0)
            {
                _remainingQuestions = new List<string>(_questions);
            }

            int index = _random.Next(_remainingQuestions.Count);
            string question = _remainingQuestions[index];
            _remainingQuestions.RemoveAt(index);
            return question;
        }

        private string GetRandomItem(List<string> items)
        {
            return items[_random.Next(items.Count)];
        }
    }
}
