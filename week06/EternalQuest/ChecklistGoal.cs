using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;

        int gainedPoints = GetPoints();
        bool justCompleted = _currentCount == _targetCount;

        if (justCompleted)
        {
            gainedPoints += _bonusPoints;
            Console.WriteLine($"Great job! You completed the checklist goal \"{GetShortName()}\".");
            Console.WriteLine($"You earned {GetPoints()} points + {_bonusPoints} bonus points = {gainedPoints} total.");
        }
        else
        {
            Console.WriteLine($"Progress recorded for \"{GetShortName()}\". You earned {GetPoints()} points.");
            Console.WriteLine($"Current progress: {_currentCount}/{_targetCount}");
        }

        return gainedPoints;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetShortName()} ({GetDescription()}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|name|description|points|targetCount|currentCount|bonusPoints
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }
}
