using System;

public class Mouse : Mammal
{
    const double increaseWeight = 0.10;

    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return "Squeak";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
        {
            this.FoodEaten = 0;
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * increaseWeight;
        this.FoodEaten += food.Quantity;
    }
}

