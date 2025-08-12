using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;

                if (_amountCompleted == _target)
                {
                    return _points + _bonus; // Regular points plus bonus
                }
                else
                {
                    return _points; // Just regular points
                }
            }
            return 0; // Already completed
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description}) - Completed {_amountCompleted}/{_target} times - {_points} points each, {_bonus} bonus";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }

        public void SetAmountCompleted(int amount)
        {
            _amountCompleted = amount;
        }

        public int GetAmountCompleted()
        {
            return _amountCompleted;
        }

        public int GetTarget()
        {
            return _target;
        }

        public int GetBonus()
        {
            return _bonus;
        }
    }
}
