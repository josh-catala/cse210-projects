using System;

namespace EternalQuest
{
    // Abstract base class for all goal types.
    // Holds the state and behavior every goal shares (encapsulation: fields are
    // private, exposed only through protected/public properties as needed) and
    // declares the members each derived class must supply its own version of
    // (polymorphism).
    public abstract class Goal
    {
        private string _name;
        private int _points;
        private bool _isComplete;

        protected Goal(string name, int points)
        {
            _name = name;
            _points = points;
            _isComplete = false;
        }

        public string Name => _name;
        public int Points => _points;

        // Derived classes can update completion status, but nothing outside
        // the class hierarchy can flip this directly.
        public bool IsComplete
        {
            get => _isComplete;
            protected set => _isComplete = value;
        }

        // Called whenever the user records progress on this goal.
        // Returns the number of points earned (can be negative for bad-habit
        // goals) so the caller can update the running score.
        public abstract int RecordEvent();

        // A single line describing the goal's current state, formatted for
        // the goal list display (e.g. "[X] Run a marathon (1000 points)").
        public abstract string GetDetailsString();

        // A pipe/colon-delimited line used to persist this goal to disk and
        // rebuild it later. The first token is always the goal's type name
        // so GoalManager knows which subclass to reconstruct.
        public abstract string GetStringRepresentation();
    }
}
