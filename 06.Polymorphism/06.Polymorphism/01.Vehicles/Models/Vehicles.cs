public abstract class Vehicles
{
    public Vehicles(double fuelQuantity, double fuelLitersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelLitersPerKm = fuelLitersPerKm;
    }

    public double FuelQuantity { get; set; }

    public double FuelLitersPerKm { get; set; }

    public virtual string DrivenAGivenDistance(double km)
    {
        double fuelForDistance = km * this.FuelLitersPerKm;
        if (fuelForDistance <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelForDistance;
            return $"{this.GetType().Name} travelled {km} km";
        }
        return $"{this.GetType().Name} needs refueling";
    }
   
    public virtual void RefueledVehicles(double liters)
    {
        FuelQuantity += liters;
    }

    public override string ToString()
    {
        string fuel = $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        return fuel;
    }
}

