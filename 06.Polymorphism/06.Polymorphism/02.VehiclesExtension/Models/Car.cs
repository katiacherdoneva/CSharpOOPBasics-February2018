public class Car : Vehicles
{
    const double increasedFuel = 0.9;

    public Car(double fuelQuantity, double fuelLitersPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelLitersPerKm + increasedFuel, tankCapacity)
    {
    }
}

