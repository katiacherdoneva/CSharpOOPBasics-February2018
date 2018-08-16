public class Truck : Vehicles
{
    const double increasedFuel = 1.6;

    public Truck(double fuelQuantity, double fuelLitersPerKm) : base(fuelQuantity, fuelLitersPerKm + increasedFuel)
    {
    }

    public override void RefueledVehicles(double liters)
    {
        base.RefueledVehicles(liters * 0.95);
    }
}

