using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
/* tasks
DONE get program to run
get the loop with exit to run
add breathing activity just console message
add reflection activity just console message
add listening activity just console message
add base functionality 
implement breathing activity
    display starting message and prompt
    read response
    start timer
    breath in, breath out
    once reached countdown, stop
    print finish message
implement reflection activity
display starting message and prompt
    read response
    start timer
    array of random prompts
    once reached countdown, stop
    print finish message

*/

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectionActivty(),
            new ListingActivty(),
        };

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("*** Mindfulness Program ***");
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activty");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            int index;
            if (int.TryParse(choice, out index) && index >= 1 && index <= 3)
            {
                activities[index - 1].Start();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}