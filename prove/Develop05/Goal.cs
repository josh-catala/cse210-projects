using System;

namespace EternalQuest
{
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

        // Fixed: replaced expression-bodied properties with getter methods
        public string GetName()
        {
            return _name;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool GetIsComplete()
        {
            return _isComplete;
        }

        // Fixed: replaced property setter with protected method
        protected void SetIsComplete(bool value)
        {
            _isComplete = value;
        }

        public abstract int RecordEvent();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();
    }
}
