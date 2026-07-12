using System;

namespace EternalQuest
{
    // CREATIVE ADDITION: a "negative goal" for a bad habit you're trying to
    // quit, e.g. "Stayed up too late". Recording it costs points instead of
    // earning them, and it is never "complete" - the whole point is that you
    // want the count (and the point loss) to stay as low as possible.
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
            return -Points;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {Name} (-{Points} points each slip, happened {_timesRecorded} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{Name}:{Points}:{_timesRecorded}";
        }

        public static NegativeGoal CreateFromString(string[] parts)
        {
            // parts: [0]=type [1]=name [2]=points [3]=timesRecorded
            return new NegativeGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }
}
