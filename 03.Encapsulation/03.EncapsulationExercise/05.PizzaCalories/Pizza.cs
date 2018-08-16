using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza()
    {
        toppings = new List<Topping>();
    }
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double SumOfCalories()
    {
        double sum = Dough.Callories();

        foreach (var topping in toppings)
        {
            sum += topping.Callories();
        }

        return sum;
    }

    public override string ToString()
    {
        return $"{Name} - {SumOfCalories():f2} Calories.";
    }
}

