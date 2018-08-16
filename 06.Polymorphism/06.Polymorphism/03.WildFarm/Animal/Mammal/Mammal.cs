public abstract class Mammal : Animal, IMammal
{
    public Mammal(string name, double weight, string livingRegion)
    : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

