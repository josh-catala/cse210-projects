using System;

namespace EternalQuest
{
    // A goal that is never "finished" - each recording just earns more
    // points, e.g. "Read your scriptures".
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
            return Points;
        }

        public override string GetDetailsString()
        {
            // Eternal goals are never checked off, but we show how many
            // times it has been recorded so the user can see momentum.
            return $"[ ] {Name} ({Points} points each time, recorded {_timesRecorded} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name}:{Points}:{_timesRecorded}";
        }

        public static EternalGoal CreateFromString(string[] parts)
        {
            // parts: [0]=type [1]=name [2]=points [3]=timesRecorded
            return new EternalGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }
}
