using System;

public class Swimming : Activity
{
    private int _lapCount;

    // lapCount is the number of 50m laps
    public Swimming(DateTime date, int lengthMinutes, int lapCount)
        : base(date, lengthMinutes, "Swimming")
    {
        _lapCount = lapCount;
    }

    public override double GetDistance()
    {
        // Distance (miles) = laps * 50m / 1000 (km) * 0.62 (km to miles)
        double distanceKm = _lapCount * 50.0 / 1000.0;
        double distanceMiles = distanceKm * 0.62;
        return distanceMiles;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = (distance / minutes) * 60
        return (GetDistance() / GetLengthMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = minutes / distance
        return GetLengthMinutes() / GetDistance();
    }
}

