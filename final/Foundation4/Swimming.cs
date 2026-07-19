using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        // Constant member variables use SCREAMING_SNAKE_CASE naming.
        private const double LAP_LENGTH_METERS = 50;
        private const double KM_TO_MILES = 0.62;

        // Regular member variable uses _camelCase naming.
        private int _laps;

        public Swimming(DateTime date, double lengthMinutes, int laps)
            : base(date, lengthMinutes)
        {
            _laps = laps;
        }

        public override string GetActivityName()
        {
            return "Swimming";
        }

        public override double GetDistance()
        {
            double distance = _laps * LAP_LENGTH_METERS / 1000 * KM_TO_MILES;
            return distance;
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
