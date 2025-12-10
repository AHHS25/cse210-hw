using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;
    private string _activityType;

    public Activity(DateTime date, int lengthMinutes, string activityType)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
        _activityType = activityType;
    }

    // These methods will be implemented in the derived classes.
    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // miles per hour
    public abstract double GetPace();     // minutes per mile

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string dateText = _date.ToString("dd MMM yyyy");

        return $"{dateText} {_activityType} ({_lengthMinutes} min) - " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, " +
               $"Pace: {pace:F1} min per mile";
    }
}
