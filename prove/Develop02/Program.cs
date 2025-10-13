using System;
using System.Net.Quic;
using System.Collections;
using System.Diagnostics;
//get random prompt
class Program
{
    static Journal journal = new Journal();
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        bool exit = false;
        do
        {
            printMenu();

            string input = getUserInput();

            if (input.Equals("5"))
            {
                exit = true;
            }

            if (input.Equals("1"))
            {
                createJournalEntry();
            }

            if (input.Equals("2"))
            {
                journal.printEntries();
            }

            if (input.Equals("3"))
            {
                loadJournal();
            }

            if (input.Equals("4"))
            {
                saveJournal();
            }

        } while (!exit);

    }

    static void printMenu()
    {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do?");
    }
    static string getUserInput()
    {
        string input = Console.ReadLine();
        return input;
    }
    static void createJournalEntry()
    {
        string prompt = getRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string input = getUserInput();
        JournalEntry entry = new JournalEntry();
        entry.answer = input;
        entry.prompt = prompt;
        entry.date = DateTime.Now;

        journal.addToJournal(entry);

    }

    static string getRandomPrompt()
    {
        string[] prompts = {
            "What made you smile today?",
            "What is something you are grateful for?",
            "Describe a goal you want to achieve this week.",
            "What is a challenge you overcame recently?",
            "Write about someone who inspires you."
        };
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    static void loadJournal()
    {
        Console.WriteLine("What is the file name? ");
        string input = getUserInput();

        journal.load(input);
    }

    static void saveJournal()
    {
        Console.WriteLine("What is the file name? ");
        string input = getUserInput();
        journal.save(input);
    }
}

class JournalEntry
{
    public DateTime date;
    public string prompt;
    public string answer;

    override public string ToString()
    {
        string myString = "Date: " + date.ToShortDateString() + " - Prompt: " + prompt + "\n" + answer;
        return myString;

    }
    public string toFileString()
    {
        string myString = date.ToShortDateString() + "Prompt:" + prompt + "Response" + answer;
        return myString;
    }
    public static JournalEntry fromFileString(string line)
    {
        string[] split = line.Split("###");
        JournalEntry finalDisplay = new JournalEntry();
        Console.WriteLine(split[0]);

        finalDisplay.date = DateTime.Parse(split[0]);
        finalDisplay.prompt = split[1];
        finalDisplay.answer = split[2];

        return finalDisplay;

    }
}

class Journal
{
    public ArrayList journalEntries = new ArrayList();
    public void addToJournal(JournalEntry journalEntry)
    {
        journalEntries.Add(journalEntry);
    }
    public void printEntries()
    {
        foreach (var entry in journalEntries)
        {
            Console.WriteLine(entry);
            Console.WriteLine();
        }
    }
    public void save(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (JournalEntry entry in journalEntries)
            {
                outputFile.WriteLine(entry.toFileString());
            }

        }
    }
    public void load(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        this.journalEntries = new ArrayList();

        foreach (string line in lines)
        {
            JournalEntry entry = JournalEntry.fromFileString(line);
            this.journalEntries.Add(entry);
        }

    }
}