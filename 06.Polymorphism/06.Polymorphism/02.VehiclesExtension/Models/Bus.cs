using System;

public class Bus : Vehicles
{
    const double increasedFuel = 1.4;

    public Bus(double fuelQuantity, double fuelLitersPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelLitersPerKm, tankCapacity)
    {
    }

    public override void DrivenAGivenDistance(double km, bool hasAC)
    {
        double totalFuelLitersPerKm = this.FuelLitersPerKm;
        if (hasAC)
        {
            totalFuelLitersPerKm += increasedFuel;
        }

        double fuelForDistance = km * totalFuelLitersPerKm;
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
}

