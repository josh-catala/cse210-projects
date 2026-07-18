using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        private const int PointsPerLevel = 1000;
        private readonly int[] _badgeThresholds = { 500, 1000, 2500, 5000, 10000 };
        private HashSet<int> _announcedBadges = new HashSet<int>();

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        // Fixed: replaced expression-bodied properties with getter methods
        public int GetScore()
        {
            return _score;
        }

        public int GetLevel()
        {
            int raw = _score < 0 ? 0 : _score;
            return raw / PointsPerLevel + 1;
        }

        private int PointsIntoLevel()
        {
            int raw = _score < 0 ? 0 : _score;
            return raw % PointsPerLevel;
        }

        public void DisplayPlayerStatus()
        {
            int intoLevel = PointsIntoLevel();
            int barLength = 20;
            double fraction = (double)intoLevel / PointsPerLevel;
            int filled = (int)Math.Round(fraction * barLength);
            string bar = new string('#', filled) + new string('-', barLength - filled);

            Console.WriteLine();
            Console.WriteLine($"Score: {_score} points");
            Console.WriteLine($"Level: {GetLevel()}  [{bar}] {intoLevel}/{PointsPerLevel} to next level");
            Console.WriteLine();
        }

        public void DisplayGoals()
        {
            Console.WriteLine();
            if (_goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create one from the main menu!");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
                }
            }
            Console.WriteLine();
        }

        public void CreateGoalMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What type of goal would you like to create?");
            Console.WriteLine("  1. Simple Goal      (done once, e.g. Run a marathon)");
            Console.WriteLine("  2. Eternal Goal      (never finished, e.g. Read scriptures)");
            Console.WriteLine("  3. Checklist Goal    (done a set number of times, e.g. Temple x10)");
            Console.WriteLine("  4. Progress Goal     (log units toward one big goal, e.g. train for a marathon)");
            Console.WriteLine("  5. Negative Goal     (a bad habit that costs you points)");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Console.Write("Goal name: ");
            string name = Console.ReadLine();
            if (name == null) name = "";

            if (choice == "1")
            {
                int points = ReadInt("Points for completing it: ");
                _goals.Add(new SimpleGoal(name, points));
            }
            else if (choice == "2")
            {
                int points = ReadInt("Points earned each time it's recorded: ");
                _goals.Add(new EternalGoal(name, points));
            }
            else if (choice == "3")
            {
                int points = ReadInt("Points earned each time it's recorded: ");
                int target = ReadInt("Number of times required to complete it: ");
                int bonus = ReadInt("Bonus points awarded on completion: ");
                _goals.Add(new ChecklistGoal(name, points, target, bonus));
            }
            else if (choice == "4")
            {
                Console.Write("Unit of progress (e.g. miles, chapters, pages): ");
                string unit = Console.ReadLine();
                if (unit == null) unit = "units";
                int points = ReadInt($"Points earned per {unit}: ");
                int target = ReadInt($"Total {unit} needed to complete the goal: ");
                int bonus = ReadInt("Bonus points awarded on completion: ");
                _goals.Add(new ProgressGoal(name, points, target, bonus, unit));
            }
            else if (choice == "5")
            {
                int points = ReadInt("Points lost each time it happens: ");
                _goals.Add(new NegativeGoal(name, points));
            }
            else
            {
                Console.WriteLine("That's not a valid option, no goal was created.");
                return;
            }

            Console.WriteLine($"Goal \"{name}\" created!");
        }

        public void RecordEventMenu()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals to record yet.");
                return;
            }

            DisplayGoals();
            int index = ReadInt("Which goal did you accomplish? (enter the number): ") - 1;

            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("That's not a valid goal number.");
                return;
            }

            Goal goal = _goals[index];
            int earned;

            if (goal is ProgressGoal)
            {
                ProgressGoal progressGoal = (ProgressGoal)goal;
                int amount = ReadInt("How many units of progress did you make? ");
                earned = progressGoal.RecordProgress(amount);
            }
            else
            {
                earned = goal.RecordEvent();
            }

            ApplyPoints(earned, goal);
        }

        private void ApplyPoints(int earned, Goal goal)
        {
            int levelBefore = GetLevel();
            _score += earned;

            if (earned > 0)
            {
                Console.WriteLine($"Nice work! You earned {earned} points.");
            }
            else if (earned < 0)
            {
                Console.WriteLine($"That one cost you {-earned} points. Keep working on it!");
            }
            else
            {
                Console.WriteLine("That goal is already complete - nothing more to record.");
            }

            if (goal.GetIsComplete())
            {
                Console.WriteLine($"Goal \"{goal.GetName()}\" is now complete!");
            }

            if (GetLevel() > levelBefore)
            {
                Console.WriteLine($"*** LEVEL UP! You are now level {GetLevel()}! ***");
            }

            foreach (int threshold in _badgeThresholds)
            {
                if (_score >= threshold && !_announcedBadges.Contains(threshold))
                {
                    _announcedBadges.Add(threshold);
                    Console.WriteLine($"*** BADGE UNLOCKED: {threshold}-point milestone! ***");
                }
            }
        }

        private int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Please enter a whole number.");
            }
        }

        public void SaveGoals(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);

                // Build badge string manually without lambdas
                List<string> badgeTokens = new List<string>();
                foreach (int badge in _announcedBadges)
                {
                    badgeTokens.Add(badge.ToString());
                }
                writer.WriteLine(string.Join(",", badgeTokens));

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {filename}.");
        }

        public void LoadGoals(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Couldn't find a file named {filename}.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length < 2)
            {
                Console.WriteLine("That file doesn't look like a valid saved quest.");
                return;
            }

            _goals = new List<Goal>();
            _score = int.Parse(lines[0]);

            _announcedBadges = new HashSet<int>();
            if (!string.IsNullOrWhiteSpace(lines[1]))
            {
                foreach (string token in lines[1].Split(','))
                {
                    if (int.TryParse(token, out int badge))
                    {
                        _announcedBadges.Add(badge);
                    }
                }
            }

            for (int i = 2; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] parts = lines[i].Split(':');
                string type = parts[0];

                // Fixed: replaced switch expression (=>) with if/else chain
                Goal goal = null;
                if (type == "SimpleGoal")
                    goal = SimpleGoal.CreateFromString(parts);
                else if (type == "EternalGoal")
                    goal = EternalGoal.CreateFromString(parts);
                else if (type == "ChecklistGoal")
                    goal = ChecklistGoal.CreateFromString(parts);
                else if (type == "ProgressGoal")
                    goal = ProgressGoal.CreateFromString(parts);
                else if (type == "NegativeGoal")
                    goal = NegativeGoal.CreateFromString(parts);

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine($"Goals loaded from {filename}.");
        }
    }
}
