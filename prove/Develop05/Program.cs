using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("        MENU");
            Console.WriteLine("====================");
            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    //        CREATE GOAL
    static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Choose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nEnter choice: ");

        string input = Console.ReadLine();

        Console.Write("\nGoal Name: ");
        string name = Console.ReadLine();

        Console.Write("Goal Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (input)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times needed to complete? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points when complete: ");
                int bonus = int.Parse(Console.ReadLine());

                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid Goal Type.");
                break;
        }

        Console.WriteLine("\nGoal created!");
        Console.WriteLine("Press ENTER to return to the menu...");
        Console.ReadLine();
    }

    // ============================
    //        LIST GOALS
    // ============================
    static void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("==== YOUR GOALS ====\n");

        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
            }
        }

        Console.WriteLine($"\nTotal Score: {score}");
        Console.WriteLine("\nPress ENTER to return to the menu...");
        Console.ReadLine();
    }
    //        RECORD EVENT
    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            return;
        }

        ListGoals();
        Console.Write("\nWhich goal did you accomplish? (number): ");

        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            return;
        }

        int earned = goals[index].RecordEvent();
        score += earned;

        Console.WriteLine($"\nYou earned {earned} points!");
        Console.WriteLine($"New Total Score: {score}");

        Console.WriteLine("\nPress ENTER to return to the menu...");
        Console.ReadLine();
    }

    //        SAVE GOALS
    static void SaveGoals()
    {
        Console.Write("\nFilename to save to: ");
        string file = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(score);
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.SaveData());
            }
        }

        Console.WriteLine("Goals saved!");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
    //        LOAD GOALS
    static void LoadGoals()
    {
        Console.Write("\nFilename to load from: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found!");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            return;
        }

        string[] lines = File.ReadAllLines(file);
        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            goals.Add(Goal.LoadGoal(lines[i]));
        }

        Console.WriteLine("Goals loaded!");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }
}
