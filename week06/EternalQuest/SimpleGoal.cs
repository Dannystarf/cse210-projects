using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string checkbox = _isComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description}) - {_points} points";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }

        public void SetComplete(bool complete)
        {
            _isComplete = complete;
        }
    }
}
