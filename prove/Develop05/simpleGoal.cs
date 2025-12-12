class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool done = false)
        : base(name, description, points)
    {
        _completed = done;
    }

    public override int RecordEvent()
    {
        _completed = true;
        return _points;
    }

    public override string GetStatus()
    {
        string check = _completed ? "[X]" : "[ ]";
        return $"{check} {_name} — {_description}";
    }

    public override string SaveData()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_completed}";
    }
}
