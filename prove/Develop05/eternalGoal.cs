class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStatus()
    {
        return $"[∞] {_name} — {_description}";
    }

    public override string SaveData()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
