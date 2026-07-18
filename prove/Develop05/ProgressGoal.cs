using System;

namespace EternalQuest
{
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
            SetIsComplete(_currentProgress >= _targetProgress);
        }

        public override int RecordEvent()
        {
            return RecordProgress(1);
        }

        public int RecordProgress(int amount)
        {
            if (GetIsComplete() || amount <= 0)
            {
                return 0;
            }

            int remaining = _targetProgress - _currentProgress;
            int applied = Math.Min(amount, remaining);
            _currentProgress += applied;
            int earned = applied * GetPoints();

            if (_currentProgress >= _targetProgress)
            {
                SetIsComplete(true);
                earned += _bonus;
            }

            return earned;
        }

        public override string GetDetailsString()
        {
            string check = GetIsComplete() ? "[X]" : "[ ]";
            int barLength = 20;
            double fraction = _targetProgress == 0 ? 0 : (double)_currentProgress / _targetProgress;
            double clamped = fraction < 0 ? 0 : (fraction > 1 ? 1 : fraction);
            int filled = (int)Math.Round(clamped * barLength);
            string bar = new string('#', filled) + new string('-', barLength - filled);

            return $"{check} {GetName()} [{bar}] {_currentProgress}/{_targetProgress} {_unit} " +
                   $"({GetPoints()} points/{_unit}, +{_bonus} bonus on completion)";
        }

        public override string GetStringRepresentation()
        {
            return $"ProgressGoal:{GetName()}:{GetPoints()}:{_targetProgress}:{_bonus}:{_unit}:{_currentProgress}";
        }

        public static ProgressGoal CreateFromString(string[] parts)
        {
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
