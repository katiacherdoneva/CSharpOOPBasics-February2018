using System.Collections.Generic;

public class DriverFactory
{
    public static Driver CreaterDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        Tyre tyre = TyreFactory.CreateTyre(tyreType, tyreHardness, commandArgs);
        Car car = new Car(hp, fuelAmount, tyre);

        Driver driver = null;
        if (type == "Aggressive")
        {

            driver = new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }
        return driver;
    }
}

