using System;

namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        private int _timesRecorded;

        public NegativeGoal(string name, int points, int timesRecorded = 0)
            : base(name, points)
        {
            _timesRecorded = timesRecorded;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return -GetPoints();
        }

        public override string GetDetailsString()
        {
            return $"[ ] {GetName()} (-{GetPoints()} points each slip, happened {_timesRecorded} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{GetName()}:{GetPoints()}:{_timesRecorded}";
        }

        public static NegativeGoal CreateFromString(string[] parts)
        {
            return new NegativeGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }
}
