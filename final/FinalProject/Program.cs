using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        RecipeBook recipeBook = new RecipeBook();
        Pantry pantry = new Pantry();
        MealPlan mealPlan = new MealPlan();
        GroceryList groceryList = new GroceryList();

        bool running = true;
        while (running)
        {
            Console.Clear(); // Clear the screen for a clean menu
            Console.WriteLine("--- Meal Planner ---");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. Add Pantry Item");
            Console.WriteLine("3. Plan Meals");
            Console.WriteLine("4. Display Meal Plan");
            Console.WriteLine("5. Generate Grocery List");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRecipe(recipeBook);
                    break;
                case "2":
                    AddPantryItem(pantry);
                    break;
                case "3":
                    PlanMeals(recipeBook, mealPlan);
                    break;
                case "4":
                    Console.Clear();
                    mealPlan.ListAllMeals();
                    Console.WriteLine("\nPress Enter to go back to the menu...");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    groceryList.GenerateFromMealPlan(mealPlan, pantry);
                    groceryList.ListItems();
                    Console.WriteLine("\nPress Enter to go back to the menu...");
                    Console.ReadLine();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddRecipe(RecipeBook recipeBook)
    {
        Console.Write("Enter meal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select meal type: 1-Breakfast 2-Lunch 3-Dinner");
        string type = Console.ReadLine();
        Meal meal;

        if (type == "1") meal = new Breakfast(name);
        else if (type == "2") meal = new Lunch(name);
        else meal = new Dinner(name);

        bool adding = true;
        while (adding)
        {
            Console.Write("Add ingredient (name quantity unit) or 'done': ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done")
            {
                adding = false;
            }
            else
            {
                var parts = input.Split(' ');
                if (parts.Length < 3)
                {
                    Console.WriteLine("Invalid format. Try again.");
                    continue;
                }

                double quantity;
                if (!double.TryParse(parts[parts.Length - 2], out quantity))
                {
                    Console.WriteLine("Invalid quantity. Try again.");
                    continue;
                }
                string unit = parts[parts.Length - 1];
                string ingredientName = string.Join(" ", parts, 0, parts.Length - 2);

                meal.AddIngredient(new Ingredient(ingredientName, quantity, unit));
            }
        }

        recipeBook.AddMeal(meal);
    }

    static void AddPantryItem(Pantry pantry)
    {
        Console.Write("Enter ingredient (name quantity unit): ");
        string input = Console.ReadLine();
        var parts = input.Split(' ');

        if (parts.Length < 3)
        {
            Console.WriteLine("Invalid format. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        double quantity;
        if (!double.TryParse(parts[parts.Length - 2], out quantity))
        {
            Console.WriteLine("Invalid quantity. Press Enter to continue.");
            Console.ReadLine();
            return;
        }
        string unit = parts[parts.Length - 1];
        string ingredientName = string.Join(" ", parts, 0, parts.Length - 2);

        pantry.AddIngredient(new Ingredient(ingredientName, quantity, unit));
    }

    static void PlanMeals(RecipeBook recipeBook, MealPlan mealPlan)
    {
        Console.Write("Enter day of the week: ");
        string day = Console.ReadLine();

        recipeBook.ListAllMeals();
        Console.Write("Enter meal name to add: ");
        string mealName = Console.ReadLine();

        Meal meal = recipeBook.GetMeal(mealName);
        if (meal != null)
        {
            mealPlan.AddMeal(day, meal);
        }
    }
}