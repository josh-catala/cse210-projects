using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points, bool isComplete = false)
            : base(name, points)
        {
            SetIsComplete(isComplete);
        }

        public override int RecordEvent()
        {
            if (GetIsComplete())
            {
                return 0;
            }

            SetIsComplete(true);
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            string check = GetIsComplete() ? "[X]" : "[ ]";
            return $"{check} {GetName()} ({GetPoints()} points)";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetName()}:{GetPoints()}:{GetIsComplete()}";
        }

        public static SimpleGoal CreateFromString(string[] parts)
        {
            return new SimpleGoal(parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
        }
    }
}
