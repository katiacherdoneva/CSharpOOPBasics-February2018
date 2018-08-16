using System;

public class Tiger : Feline
{
    const double increaseWeight = 1.00;

    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string MakeSound()
    {
        return "ROAR!!!";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            this.FoodEaten = 0;
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * increaseWeight;
        this.FoodEaten += food.Quantity;
    }
}

