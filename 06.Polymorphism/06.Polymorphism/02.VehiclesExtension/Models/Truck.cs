using System;

public class Truck : Vehicles
{
    const double increasedFuel = 1.6;

    public Truck(double fuelQuantity, double fuelLitersPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelLitersPerKm + increasedFuel, tankCapacity)
    {
    }

    public override void RefueledVehicles(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        this.addLiters = liters;
        liters *= 0.95;

        double totalAddFuel = liters + this.FuelQuantity;
        if (totalAddFuel > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {addLiters} fuel in the tank");
        }

        FuelQuantity += liters;
    }
}

