using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, int points, int timesRecorded = 0)
            : base(name, points)
        {
            _timesRecorded = timesRecorded;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            return $"[ ] {GetName()} ({GetPoints()} points each time, recorded {_timesRecorded} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{GetName()}:{GetPoints()}:{_timesRecorded}";
        }

        public static EternalGoal CreateFromString(string[] parts)
        {
            return new EternalGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }
}
