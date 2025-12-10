using System;

public class Cycling : Activity
{
    private double _speedMph;

    // speedMph is the average speed for this ride in miles per hour
    public Cycling(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes, "Cycling")
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        // Distance (miles) = speed * time(hours)
        return _speedMph * (GetLengthMinutes() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = 60 / speed
        return 60.0 / _speedMph;
    }
}
