using System;

public class Owl : Bird
{
    const double increaseWeight = 0.25;
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override string MakeSound()
    {
        return "Hoot Hoot";
    }

    public override void Eat(Food food)
    {
        if(food.GetType().Name != "Meat")
        {
            this.FoodEaten = 0;
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * increaseWeight;
        this.FoodEaten += food.Quantity;
    }
}

