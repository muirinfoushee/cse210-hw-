using System;
using System.Collections.Generic;

public class Pantry
{
    private List<Ingredient> ingredients;

    public Pantry()
    {
        ingredients = new List<Ingredient>();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void RemoveIngredient(string ingredientName)
    {
        ingredients.RemoveAll(i => i.Name == ingredientName);
    }

    public bool HasIngredient(Ingredient ingredient)
    {
        foreach (var item in ingredients)
        {
            if (item.Name == ingredient.Name && item.Quantity >= ingredient.Quantity)
                return true;
        }
        return false;
    }

    public List<Ingredient> GetIngredients()
    {
        return new List<Ingredient>(ingredients);
    }
}
