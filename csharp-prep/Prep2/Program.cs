using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter grade: ");
        string valueFromUser = Console.ReadLine();

        int x = int.Parse(valueFromUser);
        int a = 90;
        int b = 80;
        int c = 70;
        int d = 60;

        string letter = "";

        if (x >= a)
        {
            letter = "A";
        }
        else if (x >= b)
        {
            letter = "B";
        }
        else if (x >= c)
        {
            letter = "C";
        }
        else if (x >= d)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
         Console.WriteLine($"Your grade is: {letter}");

        if (x >= c)
        {
            Console.WriteLine("Congrats! You passed the course. ");
        }
        else
        {
            Console.WriteLine("You didn't pass, goodluck next time. ");
        }
       
    }
}