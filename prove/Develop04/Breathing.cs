class BreathingActivity : Activity
{
    public BreathingActivity()
    : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }
    protected override void RunActivity(int durationSeconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in...");
            Countdown(4);

            Console.WriteLine();

            Console.Write("Now breath out...");
            Countdown(6);

            Console.WriteLine("\n");
        }
    }
}