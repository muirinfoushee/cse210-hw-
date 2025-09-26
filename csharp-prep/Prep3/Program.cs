using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("Enter the magic number (keep it secret!): ");
        //int magicNumber = int.Parse(Console.ReadLine());
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);


        int guess = -1; // Initialize guess with a value that can't be correct

        // Loop until the user guesses correctly
        while (guess != magicNumber)
        {
            Console.Write("Guess the magic number: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Too low! Try guessing higher next time.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high! Try guessing lower next time.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number.");
            }
        }
    }
}
 