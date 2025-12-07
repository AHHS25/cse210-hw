using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal \"{GetShortName()}\". You earned {GetPoints()} points.");
        return GetPoints();
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetDetailsString()
    {
        // Always shows as not completed
        return $"[ ] {GetShortName()} ({GetDescription()}) (Eternal)";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|name|description|points
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }
}
