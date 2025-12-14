public class Breakfast : Meal
{
    public Breakfast(string name) : base(name) { }

    public override string GetMealType()
    {
        return "Breakfast";
    }
}

public class Lunch : Meal
{
    public Lunch(string name) : base(name) { }

    public override string GetMealType()
    {
        return "Lunch";
    }
}

public class Dinner : Meal
{
    public Dinner(string name) : base(name) { }

    public override string GetMealType()
    {
        return "Dinner";
    }
}
