using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        // TODO: Replace this comment with a description of how you exceeded
        // the assignment requirements, as required by the syllabus (item #8).
        // For example: extra activity types, unit tests, input validation, etc.

        static void Main(string[] args)
        {
            // Build one list that can hold every kind of activity, because
            // Running, Cycling, and Swimming all derive from Activity.
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
            activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 12.0));
            activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 40));

            // Call GetSummary() on each item. Even though the list is typed
            // as Activity, each object runs its own overridden calculation
            // logic - this is polymorphism in action.
            foreach (Activity activity in activities)
            {
                string summary = activity.GetSummary();
                Console.WriteLine(summary);
            }
        }
    }
}
