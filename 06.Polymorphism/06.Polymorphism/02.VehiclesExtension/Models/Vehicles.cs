using System;

public abstract class Vehicles
{
    double fuelQuantity = 0;
    protected double addLiters;

    public Vehicles(double fuelQuantity, double fuelLitersPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        this.FuelLitersPerKm = fuelLitersPerKm;
    }

    public double TankCapacity { get; set; }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double FuelLitersPerKm { get; set; }

    public virtual void DrivenAGivenDistance(double km, bool hasAC)
    {
        double fuelForDistance = km * this.FuelLitersPerKm;
        if (fuelForDistance <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelForDistance;
            Console.WriteLine($"{this.GetType().Name} travelled {km} km"); 
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void DrivenAGivenDistance(double km)
    {
        this.DrivenAGivenDistance(km, true);
    }
    public virtual void RefueledVehicles(double liters)
    {
        if(liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        this.addLiters = liters;
        double totalAddFuel = addLiters + this.FuelQuantity;
        if (totalAddFuel > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {addLiters} fuel in the tank");
        }

        FuelQuantity += liters;
    }

    public override string ToString()
    {
        string fuel = $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        return fuel;
    }
}

