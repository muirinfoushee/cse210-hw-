using System;
using System.Collections.Generic;

public class RecipeBook
{
    private List<Meal> meals;

    public RecipeBook()
    {
        meals = new List<Meal>();
    }

    public void AddMeal(Meal meal)
    {
        meals.Add(meal);
    }

    public void RemoveMeal(string mealName)
    {
        meals.RemoveAll(m => string.Equals(m.Name, mealName, StringComparison.OrdinalIgnoreCase));
    }

    public Meal GetMeal(string mealName)
    {
        return meals.Find(m => string.Equals(m.Name, mealName, StringComparison.OrdinalIgnoreCase));
    }

    public void ListAllMeals()
    {
        Console.WriteLine("Available Recipes:");
        foreach (var meal in meals)
        {
            Console.WriteLine($"- {meal.Name} ({meal.GetMealType()})");
        }
    }
}
