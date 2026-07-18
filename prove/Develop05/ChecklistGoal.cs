using System;

namespace EternalQuest
{
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
            SetIsComplete(_amountCompleted >= _targetCount);
        }

        public override int RecordEvent()
        {
            if (GetIsComplete())
            {
                return 0;
            }

            _amountCompleted++;
            int earned = GetPoints();

            if (_amountCompleted >= _targetCount)
            {
                SetIsComplete(true);
                earned += _bonus;
            }

            return earned;
        }

        public override string GetDetailsString()
        {
            string check = GetIsComplete() ? "[X]" : "[ ]";
            return $"{check} {GetName()} (Completed {_amountCompleted}/{_targetCount} times, " +
                   $"{GetPoints()} points each, +{_bonus} bonus on completion)";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{GetName()}:{GetPoints()}:{_targetCount}:{_bonus}:{_amountCompleted}";
        }

        public static ChecklistGoal CreateFromString(string[] parts)
        {
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
