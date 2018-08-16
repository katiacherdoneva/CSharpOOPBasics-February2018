public abstract class Car
{
    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; protected set; }

    public string Model { get; protected set; }

    public int YearOfProduction { get; protected set; }

    public int Horsepower { get; protected set; }

    public int Acceleration { get; protected set; }

    public int Suspension { get; protected set; }

    public int Durability { get; protected set; }
}


