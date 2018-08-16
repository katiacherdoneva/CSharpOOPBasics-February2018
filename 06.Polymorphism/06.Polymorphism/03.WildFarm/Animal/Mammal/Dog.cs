using System;

public class Dog : Mammal
{
    const double increaseWeight = 0.40;

    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return "Woof!";
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

