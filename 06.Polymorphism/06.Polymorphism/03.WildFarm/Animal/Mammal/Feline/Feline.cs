﻿public abstract class Feline : Mammal, IFeline
{
    public Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

