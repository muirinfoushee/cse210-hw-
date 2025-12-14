using System;
using System.Collections.Generic;

public class MealPlan
{
    private Dictionary<string, List<Meal>> mealsByDay;

    public MealPlan()
    {
        mealsByDay = new Dictionary<string, List<Meal>>();
    }

    public void AddMeal(string day, Meal meal)
    {
        day = Capitalize(day); // Normalize day input
        if (!mealsByDay.ContainsKey(day))
        {
            mealsByDay[day] = new List<Meal>();
        }
        mealsByDay[day].Add(meal);
    }

    public void RemoveMeal(string day, string mealName)
    {
        day = Capitalize(day);
        if (mealsByDay.ContainsKey(day))
        {
            mealsByDay[day].RemoveAll(m => string.Equals(m.Name, mealName, StringComparison.OrdinalIgnoreCase));
        }
    }

    public List<Meal> GetMealsForDay(string day)
    {
        day = Capitalize(day);
        if (mealsByDay.ContainsKey(day))
            return new List<Meal>(mealsByDay[day]);
        return new List<Meal>();
    }

    public void ListAllMeals()
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        foreach (var day in days)
        {
            Console.WriteLine($"{day}:");
            if (mealsByDay.ContainsKey(day) && mealsByDay[day].Count > 0)
            {
                foreach (var meal in mealsByDay[day])
                {
                    Console.WriteLine($"- {meal.Name} ({meal.GetMealType()})");
                }
            }
            else
            {
                Console.WriteLine("- No meals planned");
            }
        }
    }

    private string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
}
