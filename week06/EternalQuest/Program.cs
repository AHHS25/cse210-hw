using System;

/// W06 Project: Eternal Quest Program
/// EXCEEDING REQUIREMENTS:
/// - I added a simple "level" system. The player level increases every 1000 points,
///   and the current level is displayed in the menu next to the score.
/// - This adds a basic gamification element that helps the user feel more progression over time.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
