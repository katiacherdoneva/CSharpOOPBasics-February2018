using System;

class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumptionForKM;
    private decimal distanceTraveled;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public decimal FuelConsumptionForKM
    {
        get { return fuelConsumptionForKM; }
        set { fuelConsumptionForKM = value; }
    }

    public decimal DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public Car(string model, int fuelAmount, decimal fuelConsumptionForKM)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionForKM = fuelConsumptionForKM;
        DistanceTraveled = 0;
    }

    public void MoveThatDistance(decimal km)
    {
        decimal moveThatDistance = km * fuelConsumptionForKM;

        if(FuelAmount >= moveThatDistance)
        {
            FuelAmount -= moveThatDistance;
            DistanceTraveled += km;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
