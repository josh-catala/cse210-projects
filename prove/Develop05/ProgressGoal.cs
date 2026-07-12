using System;

namespace EternalQuest
{
    // CREATIVE ADDITION: a "progress goal" for working toward one big goal in
    // measurable units, e.g. "Run a marathon" tracked in miles trained, or
    // "Read the Book of Mormon" tracked in chapters. Every unit recorded
    // earns points, and hitting the target earns a completion bonus - similar
    // to ChecklistGoal, but the user can log more than one unit at a time and
    // the display shows a simple progress bar.
    public class ProgressGoal : Goal
    {
        private int _currentProgress;
        private int _targetProgress;
        private int _bonus;
        private string _unit;

        public ProgressGoal(string name, int pointsPerUnit, int targetProgress, int bonus, string unit,
            int currentProgress = 0)
            : base(name, pointsPerUnit)
        {
            _targetProgress = targetProgress;
            _bonus = bonus;
            _unit = unit;
            _currentProgress = currentProgress;
            IsComplete = _currentProgress >= _targetProgress;
        }

        // Satisfies the abstract contract: recording with no amount specified
        // logs a single unit of progress.
        public override int RecordEvent()
        {
            return RecordProgress(1);
        }

        // Overload used by the menu so the user can log several units at once
        // (e.g. "I ran 6 miles today").
        public int RecordProgress(int amount)
        {
            if (IsComplete || amount <= 0)
            {
                return 0;
            }

            int remaining = _targetProgress - _currentProgress;
            int applied = Math.Min(amount, remaining);
            _currentProgress += applied;
            int earned = applied * Points;

            if (_currentProgress >= _targetProgress)
            {
                IsComplete = true;
                earned += _bonus;
            }

            return earned;
        }

        public override string GetDetailsString()
        {
            string check = IsComplete ? "[X]" : "[ ]";
            int barLength = 20;
            double fraction = _targetProgress == 0 ? 0 : (double)_currentProgress / _targetProgress;
            int filled = (int)Math.Round(Math.Clamp(fraction, 0, 1) * barLength);
            string bar = new string('#', filled) + new string('-', barLength - filled);

            return $"{check} {Name} [{bar}] {_currentProgress}/{_targetProgress} {_unit} " +
                   $"({Points} points/{_unit}, +{_bonus} bonus on completion)";
        }

        public override string GetStringRepresentation()
        {
            return $"ProgressGoal:{Name}:{Points}:{_targetProgress}:{_bonus}:{_unit}:{_currentProgress}";
        }

        public static ProgressGoal CreateFromString(string[] parts)
        {
            // parts: [0]=type [1]=name [2]=pointsPerUnit [3]=targetProgress
            //        [4]=bonus [5]=unit [6]=currentProgress
            return new ProgressGoal(
                parts[1],
                int.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                parts[5],
                int.Parse(parts[6])
            );
        }
    }
}
