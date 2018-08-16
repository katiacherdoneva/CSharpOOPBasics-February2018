public class Car : Vehicles
{
    const double increasedFuel = 0.9;

    public Car(double fuelQuantity, double fuelLitersPerKm) : base(fuelQuantity, fuelLitersPerKm + increasedFuel)
    {
    }
}

