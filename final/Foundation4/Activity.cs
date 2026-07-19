using System;

namespace ExerciseTracking
{
    // Base class. Holds the attributes shared by every activity type
    // (date and length) and declares the calculation methods that each
    // derived class must override.
    public abstract class Activity
    {
        // Member variables use _camelCase. They are "protected" rather than
        // "private" so the derived classes (Running, Cycling, Swimming) can
        // read them directly in their own calculations without needing a
        // property (properties are not allowed in this class).
        protected DateTime _date;
        protected double _lengthMinutes;

        public Activity(DateTime date, double lengthMinutes)
        {
            _date = date;
            _lengthMinutes = lengthMinutes;
        }

        // Abstract methods - every derived class must supply its own
        // implementation. This is the "method overriding" requirement.
        public abstract string GetActivityName();
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Shared by every activity, written once here in the base class.
        // It calls the (overridden) calculation methods polymorphically,
        // so it works correctly no matter which derived type calls it.
        public virtual string GetSummary()
        {
            string dateText = _date.ToString("dd MMM yyyy");
            string lengthText = _lengthMinutes.ToString("0");
            string distanceText = GetDistance().ToString("0.0");
            string speedText = GetSpeed().ToString("0.0");
            string paceText = GetPace().ToString("0.0");

            string summary = dateText + " " + GetActivityName() + " (" + lengthText + " min) - " +
                "Distance " + distanceText + " miles, " +
                "Speed " + speedText + " mph, " +
                "Pace: " + paceText + " min per mile";

            return summary;
        }
    }
}
