using System;

class Chicken
{
    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null || value == string.Empty || value == " ")
                throw new ArgumentException("Invailed name");
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if ((value >= 0) && (value <= 15))
                throw new ArgumentException("Invailed age");
            age = value;
        }
    }

    public int ProductPerDay
    {
        get { return CalculateProductPerDay(); }
        private set {}
    }

    private int CalculateProductPerDay()
    {
        int eggs = Age / 10;

        return eggs;
    }

    public override string ToString()
    {
        return $"Chicken {Name} (age {Age}) can produce {ProductPerDay} eggs per day.";
    }
}

