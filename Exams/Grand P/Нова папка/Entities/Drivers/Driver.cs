public abstract class Driver
{
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
    }

    public string Name { get; protected set; }

    public double TotalTime { get; protected set; }

    public Car Car { get; protected set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }

    public void IncrementTotalTime(double second)
    {
        this.TotalTime += second;
    }

    public void ReductionTotalTime(double second)
    {
        this.TotalTime -= second;
    }
}

