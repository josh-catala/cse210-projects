using System;

namespace MindfulnessProgram
{
    /*
     * ================================================================
     *  EXCEEDING CORE REQUIREMENTS -- summary of extra work done
     * ================================================================
     * 1. Added a fourth activity, GratitudeActivity, alongside the three
     *    required activities (Breathing, Reflection, Listing). It reuses
     *    the same base class with zero duplicated code, showing that the
     *    design is easily extensible.
     *
     * 2. Added an ActivityLogger class that keeps a running log of how
     *    many times each activity has been completed and the total time
     *    spent in each, and SAVES/LOADS this log to "activity_log.txt" so
     *    history persists between runs of the program. A new "View Log"
     *    menu option displays this history.
     *
     * 3. In ReflectionActivity, follow-up questions are shuffled and
     *    tracked so that no question repeats until every question in the
     *    list has been shown once during the session.
     *
     * 4. The BreathingActivity uses a more meaningful animation: instead
     *    of a plain countdown, a row of dots grows with increasing delay
     *    between each dot, so the pacing feels like it slows down near
     *    the end of each breath in/out, similar to natural breathing.
     * ================================================================
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new ActivityLogger();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("--------------------");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Gratitude Activity");
                Console.WriteLine("5) View Activity Log");
                Console.WriteLine("6) Quit");
                Console.Write("Select a choice from the menu: ");

                string? choice = Console.ReadLine();

                Activity? activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => new GratitudeActivity(),
                    _ => null
                };

                if (activity != null)
                {
                    activity.Run();
                    logger.RecordCompletion(activity.Name, activity.CompletedDurationSeconds);
                    Console.WriteLine();
                    Console.WriteLine("Press enter to return to the menu.");
                    Console.ReadLine();
                }
                else if (choice == "5")
                {
                    logger.DisplayLog();
                }
                else if (choice == "6")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("That's not a valid choice. Press enter to try again.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Thanks for taking time for mindfulness today. Goodbye!");
        }
    }
}
