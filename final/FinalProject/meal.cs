using System;
using System.Collections.Generic;

public class Meal
{
    private string name;
    private List<Ingredient> ingredients;

    public Meal(string name)
    {
        this.name = name;
        ingredients = new List<Ingredient>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void RemoveIngredient(string ingredientName)
    {
        ingredients.RemoveAll(i => i.Name == ingredientName);
    }

    public virtual void ListIngredients()
    {
        Console.WriteLine($"Ingredients for {name}:");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine(ingredient);
        }
    }

    public virtual string GetMealType()
    {
        return "Generic Meal";
    }

    public List<Ingredient> GetIngredients()
    {
        return new List<Ingredient>(ingredients); // returns a copy
    }
}
