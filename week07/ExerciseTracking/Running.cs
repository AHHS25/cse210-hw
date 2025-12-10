using System;

public class Running : Activity
{
    private double _distanceMiles;

    // distanceMiles is the distance for this run in miles
    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes, "Running")
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = (distance / minutes) * 60
        return (_distanceMiles / GetLengthMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = minutes / distance
        return GetLengthMinutes() / _distanceMiles;
    }
}
