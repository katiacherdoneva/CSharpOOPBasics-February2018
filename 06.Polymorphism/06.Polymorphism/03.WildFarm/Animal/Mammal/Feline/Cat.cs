using System;

public class Cat : Feline
{
    const double increaseWeight = 0.30;

    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string MakeSound()
    {
        return "Meow";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
        {
            this.FoodEaten = 0;
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.Weight += food.Quantity * increaseWeight;
        this.FoodEaten += food.Quantity;
    }
}

