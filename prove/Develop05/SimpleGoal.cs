using System;

namespace EternalQuest
{
    // A goal that is completed once and never again, e.g. "Run a marathon".
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points, bool isComplete = false)
            : base(name, points)
        {
            IsComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (IsComplete)
            {
                return 0;
            }

            IsComplete = true;
            return Points;
        }

        public override string GetDetailsString()
        {
            string check = IsComplete ? "[X]" : "[ ]";
            return $"{check} {Name} ({Points} points)";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name}:{Points}:{IsComplete}";
        }

        public static SimpleGoal CreateFromString(string[] parts)
        {
            // parts: [0]=type [1]=name [2]=points [3]=isComplete
            return new SimpleGoal(parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
        }
    }
}
