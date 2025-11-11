
class ReflectionActivty : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public ReflectionActivty()
    : base("Reflection Activty", "This activty will help you relfect...")
    {
    }
    protected override void RunActivity(int durationSeconds)
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"-- {prompt} ---");
        Console.Write("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions...");
        Console.Write("You may begin in: ");
        Countdown(5);
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        Console.Clear();
        while (DateTime.Now < endTime)
        {
            string question = _questions[_random.Next(_questions.Count)];
            Console.Write($"> {question} ");
            ShowSpinner(6);
            Console.WriteLine();
        }
    }
}