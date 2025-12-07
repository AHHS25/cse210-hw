using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        // If it is already complete, we do not give more points
        if (_isComplete)
        {
            Console.WriteLine("This goal is already completed. No additional points awarded.");
            return 0;
        }

        _isComplete = true;
        Console.WriteLine($"Congratulations! You have completed the goal \"{GetShortName()}\" and earned {GetPoints()} points.");
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {GetShortName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|name|description|points|isComplete
        return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}
