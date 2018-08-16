using System;

public class Citizen : SocietyMember, IBirthdate, IBuyer
{
    private const int rebelFoodPurchase = 10;

    private int food;

    public Citizen(string name, int age, string id, string birthdate) : base(id)
    {
        Name = name;
        Age = age;
        Birthdate = birthdate;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Birthdate { get; set; }

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

