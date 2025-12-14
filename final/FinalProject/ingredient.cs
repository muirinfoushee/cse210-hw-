using System;

public class Ingredient
{
    private string name;
    private double quantity;
    private string unit;

    public Ingredient(string name, double quantity, string unit)
    {
        this.name = name;
        this.quantity = quantity;
        this.unit = unit;
    }

    // Encapsulation: getters and setters
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    public override string ToString()
    {
        return $"{quantity} {unit} of {name}";
    }
}
