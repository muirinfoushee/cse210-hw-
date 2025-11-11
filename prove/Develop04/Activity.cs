using System;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;
    protected static Random _random = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void Start()
    {
        Console.Clear();
        ShowStartMessage();
        _durationSeconds = PromptForDuration();
        PrepareToBegin();
        RunActivity(_durationSeconds);
        ShowEndMessage(_durationSeconds);
        LogActivity(_name, _durationSeconds);
    }
    private void ShowStartMessage()
    {
        Console.WriteLine($"*** {_name} ***");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }
    private int PromptForDuration()
    {
        int seconds = 0;
        while (true)
        {
            Console.WriteLine("Enter duration in seconds (e.g. 30): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a positive interger for seconds.");
        }
    }
    private void PrepareToBegin()
    {
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }
    private void ShowEndMessage(int seconds)
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {_name} for {seconds} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }
    private void LogActivity(string activityName, int seconds)
    {
        try
        {
            string logLine = $"{DateTime.Now:yyy-MM-dd HH:mm:ss}\t{activityName}\t{seconds}s";
            File.AppendAllLines("activity_log.txt", new[] { logLine });
        }
        catch { }
    }
    protected void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
         Console.Write(" \b");
    
    }
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    protected abstract void RunActivity(int durationSeconds);
}
   