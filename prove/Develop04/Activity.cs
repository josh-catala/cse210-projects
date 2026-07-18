using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;
        private DateTime _activityStartTime;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Fixed: replaced properties with getter methods
        public string GetName()
        {
            return _name;
        }

        public int GetCompletedDurationSeconds()
        {
            return _durationSeconds;
        }

        protected int GetDurationSeconds()
        {
            return _durationSeconds;
        }

        public void Run()
        {
            DisplayStartingMessage();
            _activityStartTime = DateTime.Now;
            PerformActivity();
            DisplayEndingMessage();
        }

        private void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting the {_name} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();

            _durationSeconds = PromptForDuration();

            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        private void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} Activity for {_durationSeconds} seconds.");
            ShowSpinner(3);
        }

        private int PromptForDuration()
        {
            int duration;
            while (true)
            {
                Console.Write("How long, in seconds, would you like for your session? ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out duration) && duration > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a whole number greater than zero.");
            }
            return duration;
        }

        protected bool DurationElapsed()
        {
            return (DateTime.Now - _activityStartTime).TotalSeconds >= _durationSeconds;
        }

        protected double SecondsElapsed()
        {
            return (DateTime.Now - _activityStartTime).TotalSeconds;
        }

        protected void ShowSpinner(int seconds)
        {
            string[] frames = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(frames[i % frames.Length]);
                Thread.Sleep(200);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected abstract void PerformActivity();
    }
}
