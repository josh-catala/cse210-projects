using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        // Member variable uses _camelCase naming.
        private double _distanceMiles;

        public Running(DateTime date, double lengthMinutes, double distanceMiles)
            : base(date, lengthMinutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override string GetActivityName()
        {
            return "Running";
        }

        public override double GetDistance()
        {
            return _distanceMiles;
        }

        public override double GetSpeed()
        {
            double speed = (GetDistance() / _lengthMinutes) * 60;
            return speed;
        }

        public override double GetPace()
        {
            double pace = _lengthMinutes / GetDistance();
            return pace;
        }
    }
}
