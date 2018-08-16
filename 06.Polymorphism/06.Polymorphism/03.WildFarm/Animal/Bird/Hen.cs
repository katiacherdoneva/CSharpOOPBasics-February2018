public class Hen : Bird
{
    const double increaseWeight = 0.35;
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string MakeSound()
    {
        return "Cluck";
    }

    public override void Eat(Food food)
    {
        this.Weight += food.Quantity * increaseWeight;
        this.FoodEaten += food.Quantity;
    }   
}

