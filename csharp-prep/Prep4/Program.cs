using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a series of numbers (type 0 to stop):");

        do
        {
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);

            }
        } while (input != 0);

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;

        }
        Console.WriteLine($"The sum is: {sum}");

        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        Console.WriteLine($"The average is: {average}");


        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}