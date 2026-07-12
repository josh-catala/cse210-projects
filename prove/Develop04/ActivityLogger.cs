using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MindfulnessProgram
{
    /// <summary>
    /// Bonus feature to exceed core requirements: keeps a simple log of how
    /// many times each activity has been completed and the total seconds
    /// spent, persisting it to a text file so history carries across runs
    /// of the program.
    /// </summary>
    public class ActivityLogger
    {
        private const string LogFilePath = "activity_log.txt";
        private readonly Dictionary<string, (int count, int totalSeconds)> _log = new();

        public ActivityLogger()
        {
            Load();
        }

        public void RecordCompletion(string activityName, int seconds)
        {
            if (_log.TryGetValue(activityName, out var existing))
            {
                _log[activityName] = (existing.count + 1, existing.totalSeconds + seconds);
            }
            else
            {
                _log[activityName] = (1, seconds);
            }
            Save();
        }

        public void DisplayLog()
        {
            Console.Clear();
            Console.WriteLine("Activity Log");
            Console.WriteLine("-------------");
            if (_log.Count == 0)
            {
                Console.WriteLine("No activities completed yet.");
            }
            else
            {
                foreach (var entry in _log.OrderBy(e => e.Key))
                {
                    Console.WriteLine(
                        $"{entry.Key}: completed {entry.Value.count} time(s), " +
                        $"{entry.Value.totalSeconds} total seconds");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to return to the menu.");
            Console.ReadLine();
        }

        private void Save()
        {
            try
            {
                var lines = _log.Select(e => $"{e.Key},{e.Value.count},{e.Value.totalSeconds}");
                File.WriteAllLines(LogFilePath, lines);
            }
            catch (IOException)
            {
                // If saving fails, silently continue -- logging is a bonus
                // feature and shouldn't crash the main program.
            }
        }

        private void Load()
        {
            if (!File.Exists(LogFilePath))
            {
                return;
            }

            try
            {
                foreach (string line in File.ReadAllLines(LogFilePath))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[1], out int count) &&
                        int.TryParse(parts[2], out int seconds))
                    {
                        _log[parts[0]] = (count, seconds);
                    }
                }
            }
            catch (IOException)
            {
                // If loading fails, just start with an empty log.
            }
        }
    }
}
