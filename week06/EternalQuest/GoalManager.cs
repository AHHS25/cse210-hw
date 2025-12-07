using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    // EXTRA / EXCEEDING REQUIREMENTS:
    // I added a simple "level" system. The level increases every 1000 points.
    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return _score / 1000; // Example level system
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Current Score: {_score}   |   Level: {GetLevel()}");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye! Keep working on your eternal quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose from the menu.");
                    break;
            }
        }
    }

    private void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Goal newGoal = new SimpleGoal(name, description, points);
            _goals.Add(newGoal);
        }
        else if (choice == 2)
        {
            Goal newGoal = new EternalGoal(name, description, points);
            _goals.Add(newGoal);
        }
        else if (choice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());

            Goal newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
            _goals.Add(newGoal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  (No goals yet. Create one first.)");
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // First line: score
            outputFile.WriteLine(_score);

            // Next lines: each goal representation
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals and score saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        // First line is the score
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');

            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                Goal loadedGoal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(loadedGoal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal loadedGoal = new EternalGoal(name, description, points);
                _goals.Add(loadedGoal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int targetCount = int.Parse(parts[4]);
                int currentCount = int.Parse(parts[5]);
                int bonusPoints = int.Parse(parts[6]);

                Goal loadedGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints, currentCount);
                _goals.Add(loadedGoal);
            }
        }

        Console.WriteLine("Goals and score loaded successfully.");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet. Please create one first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetShortName()}");
            index++;
        }

        Console.Write("Select a goal: ");
        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You now have {_score} points. (Level: {GetLevel()})");
    }
}
