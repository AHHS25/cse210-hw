using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store different activities
        List<Activity> activities = new List<Activity>();

        // Create one activity of each type
        Activity run = new Running(new DateTime(2022, 11, 3), 30, 3.0);      // 3 miles
        Activity bike = new Cycling(new DateTime(2022, 11, 3), 45, 15.0);    // 15 mph
        Activity swim = new Swimming(new DateTime(2022, 11, 3), 40, 30);     // 30 laps

        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        // Loop through the list and display the summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
