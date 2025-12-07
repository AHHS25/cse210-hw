using System;

public abstract class Goal
{
    // Private member variables (Encapsulation)
    private string _shortName;
    private string _description;
    private int _points;

    // Constructor
    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Getters (we keep fields private, but expose read-only info)
    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Polymorphic methods – must be implemented by each derived class
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
