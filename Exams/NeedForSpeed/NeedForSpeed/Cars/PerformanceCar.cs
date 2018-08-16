using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        this.Increases = (this.Horsepower * 50) / 100;
        this.Decreases = (this.Suspension * 25) / 100;
    }

    public List<string> AddOns
    {
        get { return addOns; }
        private set { addOns = value; }
    }

    public int Increases { get; private set; }

    public int Decreases { get; private set; }

}

