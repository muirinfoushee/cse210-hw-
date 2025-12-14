using System;
using System.Collections.Generic;

public class GroceryList
{
    private List<Ingredient> itemsToBuy;

    public GroceryList()
    {
        itemsToBuy = new List<Ingredient>();
    }

    public void GenerateFromMealPlan(MealPlan mealPlan, Pantry pantry)
    {
        itemsToBuy.Clear();

        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        foreach (var day in days)
        {
            var meals = mealPlan.GetMealsForDay(day);
            if (meals.Count == 0) continue;

            foreach (var meal in meals)
            {
                foreach (var ingredient in meal.GetIngredients())
                {
                    bool found = false;

                    foreach (var pantryItem in pantry.GetIngredients())
                    {
                        if (string.Equals(pantryItem.Name, ingredient.Name, StringComparison.OrdinalIgnoreCase)
                            && pantryItem.Quantity >= ingredient.Quantity)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        var existing = itemsToBuy.Find(i => string.Equals(i.Name, ingredient.Name, StringComparison.OrdinalIgnoreCase));
                        if (existing != null)
                        {
                            existing.Quantity += ingredient.Quantity;
                        }
                        else
                        {
                            itemsToBuy.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Unit));
                        }
                    }
                }
            }
        }
    }

    public void ListItems()
    {
        Console.WriteLine("\nGrocery List:");
        if (itemsToBuy.Count == 0)
        {
            Console.WriteLine("Nothing to buy! You have everything in your pantry.");
            return;
        }

        foreach (var item in itemsToBuy)
        {
            Console.WriteLine(item);
        }
    }
}
