using System;

public class Car
{
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get
        {
            return fuelAmount;
        }
        private set
        {
            if (value > 160)
            {
                fuelAmount = 160;
            }
            else if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }

    public void FullFuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}

