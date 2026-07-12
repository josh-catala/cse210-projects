using System;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// Base class for all mindfulness activities. Encapsulates the shared
    /// starting/ending messages, timing, and animation behaviors so that
    /// each derived activity only needs to implement its own unique logic.
    /// </summary>
    public abstract class Activity
    {
        // Private fields -- only accessible through this class (encapsulation).
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;
        private DateTime _activityStartTime;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Expose read-only access to derived classes / callers without
        // allowing external code to modify the values directly.
        public string Name => _name;
        public int CompletedDurationSeconds => _durationSeconds;
        protected int DurationSeconds => _durationSeconds;

        /// <summary>
        /// Template method that defines the overall flow every activity
        /// follows: starting message -> activity-specific work -> ending
        /// message. Individual activities cannot skip or reorder these
        /// steps, which keeps the experience consistent across activities.
        /// </summary>
        public void Run()
        {
            DisplayStartingMessage();
            _activityStartTime = DateTime.Now;
            PerformActivity();
            DisplayEndingMessage();
        }

        /// <summary>
        /// Common starting message shared by every activity: name,
        /// description, duration prompt, and a short "get ready" pause.
        /// </summary>
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

        /// <summary>
        /// Common ending message shared by every activity.
        /// </summary>
        private void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} Activity for {_durationSeconds} seconds.");
            ShowSpinner(3);
        }

        /// <summary>
        /// Repeatedly asks for a valid whole number of seconds.
        /// </summary>
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

        /// <summary>
        /// Returns true once the activity's overall duration has elapsed.
        /// Derived classes use this to know when to stop looping.
        /// </summary>
        protected bool DurationElapsed()
        {
            return (DateTime.Now - _activityStartTime).TotalSeconds >= _durationSeconds;
        }

        protected double SecondsElapsed()
        {
            return (DateTime.Now - _activityStartTime).TotalSeconds;
        }

        /// <summary>
        /// Displays a simple rotating spinner animation for the given
        /// number of seconds. One of the shared "pause with animation"
        /// behaviors required by the assignment.
        /// </summary>
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

        /// <summary>
        /// Displays a countdown (e.g. 3, 2, 1) animation for the given
        /// number of seconds. Another shared "pause with animation" option.
        /// </summary>
        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        /// <summary>
        /// The unique work each activity performs. Must be implemented by
        /// every derived class (abstraction).
        /// </summary>
        protected abstract void PerformActivity();
    }
}
