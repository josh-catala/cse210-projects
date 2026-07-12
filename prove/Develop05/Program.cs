using System;

namespace EternalQuest
{
    /*
     * ============================================================
     *  Eternal Quest - Ways this program exceeds the requirements
     * ============================================================
     * 1. Two extra goal types beyond the three required:
     *      - ProgressGoal: lets the user work toward one big goal in
     *        measurable units (e.g. training miles for a marathon, or
     *        chapters read toward finishing a book of scripture). The
     *        user can log more than one unit at a time, and the goal
     *        list shows a text progress bar plus a completion bonus,
     *        just like ChecklistGoal.
     *      - NegativeGoal: models a bad habit you're trying to quit.
     *        Recording it *costs* points instead of earning them,
     *        which reframes gamification for things you want to see
     *        less of, not just more of.
     *
     * 2. A leveling system: every 1000 points earns the user a new
     *    "level", displayed with its own progress bar (Level N,
     *    X/1000 points to the next level) alongside the raw score.
     *
     * 3. Badges: crossing point milestones (500, 1000, 2500, 5000,
     *    10000) triggers a one-time "Badge Unlocked!" announcement,
     *    giving short-term rewards along the way to the bigger goals,
     *    exactly the kind of "shorter term reward" the assignment
     *    description calls out.
     *
     * 4. Save/load persists not just the goals and score, but also
     *    which badges have already been announced, so reloading a
     *    saved quest doesn't re-trigger badges the user already
     *    earned in a previous session.
     * ============================================================
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            Console.WriteLine("==============================");
            Console.WriteLine("      Welcome to Eternal Quest");
            Console.WriteLine("==============================");

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("  1. Display Player Status (score & level)");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Create New Goal");
                Console.WriteLine("  4. Record Event");
                Console.WriteLine("  5. Save Goals");
                Console.WriteLine("  6. Load Goals");
                Console.WriteLine("  0. Quit");
                Console.Write("Choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        goalManager.DisplayPlayerStatus();
                        break;
                    case "2":
                        goalManager.DisplayGoals();
                        break;
                    case "3":
                        goalManager.CreateGoalMenu();
                        break;
                    case "4":
                        goalManager.RecordEventMenu();
                        break;
                    case "5":
                        Console.Write("File name to save to (e.g. goals.txt): ");
                        goalManager.SaveGoals(Console.ReadLine() ?? "goals.txt");
                        break;
                    case "6":
                        Console.Write("File name to load from (e.g. goals.txt): ");
                        goalManager.LoadGoals(Console.ReadLine() ?? "goals.txt");
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Keep pressing forward on your Eternal Quest. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("That's not a valid option, try again.");
                        break;
                }
            }
        }
    }
}
