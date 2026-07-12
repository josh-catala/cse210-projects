using System;

namespace EternalQuest
{
    // A goal that must be recorded a set number of times to be complete,
    // e.g. "Attend the temple 10 times". Awards a bonus on the final time.
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _targetCount;
        private int _bonus;

        public ChecklistGoal(string name, int points, int targetCount, int bonus, int amountCompleted = 0)
            : base(name, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
            IsComplete = _amountCompleted >= _targetCount;
        }

        public override int RecordEvent()
        {
            if (IsComplete)
            {
                return 0;
            }

            _amountCompleted++;
            int earned = Points;

            if (_amountCompleted >= _targetCount)
            {
                IsComplete = true;
                earned += _bonus;
            }

            return earned;
        }

        public override string GetDetailsString()
        {
            string check = IsComplete ? "[X]" : "[ ]";
            return $"{check} {Name} (Completed {_amountCompleted}/{_targetCount} times, " +
                   $"{Points} points each, +{_bonus} bonus on completion)";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name}:{Points}:{_targetCount}:{_bonus}:{_amountCompleted}";
        }

        public static ChecklistGoal CreateFromString(string[] parts)
        {
            // parts: [0]=type [1]=name [2]=points [3]=targetCount [4]=bonus [5]=amountCompleted
            return new ChecklistGoal(
                parts[1],
                int.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5])
            );
        }
    }
}
