using System;

public class Topping
{
    private string toppingType;
    private double weight;
    private const double caloriesPerGram = 2;

    public Topping(string toppingType, double weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }

    public string ToppingType
    {
        get { return toppingType; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            toppingType = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
                throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
            weight = value;
        }
    }

    public double Callories()
    {
        double modifier = caloriesPerGram;

        switch (this.ToppingType.ToLower())
        {
            case "meat": modifier *= 1.2; break;
            case "veggies": modifier *= 0.8; break;
            case "cheese": modifier *= 1.1; break;
            case "sauce": modifier *= 0.9; break;
        }

        return modifier * this.Weight;
    }
}

