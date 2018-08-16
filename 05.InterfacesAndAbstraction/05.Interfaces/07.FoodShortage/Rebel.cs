public class Rebel : IBuyer
{
    private const int rebelFoodPurchase = 5;

    private int food;

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Group { get; set; }

    public int Food
    {
        get { return food; }
        set { food = value; }
    }


    public int BuyFood()
    {
        return food = rebelFoodPurchase;
    }
}

