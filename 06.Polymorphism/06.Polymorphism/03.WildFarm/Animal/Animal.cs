public abstract class Animal : IAnimal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEaten { get; set; }

    public abstract string MakeSound();

    public abstract void Eat(Food food);
}

