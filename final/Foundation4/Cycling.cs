using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        // Member variable uses _camelCase naming.
        private double _speedMph;

        public Cycling(DateTime date, double lengthMinutes, double speedMph)
            : base(date, lengthMinutes)
        {
            _speedMph = speedMph;
        }

        public override string GetActivityName()
        {
            return "Cycling";
        }

        public override double GetSpeed()
        {
            return _speedMph;
        }

        public override double GetDistance()
        {
            double distance = GetSpeed() * (_lengthMinutes / 60);
            return distance;
        }

        public override double GetPace()
        {
            double pace = 60 / GetSpeed();
            return pace;
        }
    }
}
