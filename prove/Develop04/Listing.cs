class ListingActivty : Activity
{
    private List<string> _prompts = new List<string>
    {
         "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivty()
        : base("Listing Activty", "This activty will help you reflect...")
    {
    }
    protected override void RunActivity(int durationSeconds)
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"-- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        Countdown(5);
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string? response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");
        ShowSpinner(3);
    }
}