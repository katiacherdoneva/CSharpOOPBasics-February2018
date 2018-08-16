using System;

public class StartUp
{
    static void Main()
    {
        var carInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckInfo = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var busInfo = Console.ReadLine()
                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            DriveAndRefuel(car, truck, bus);
            PrintFuelOnVehicles(car, truck, bus);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }     
    }

    private static void PrintFuelOnVehicles(Vehicles car, Vehicles truck, Vehicles bus)
    {
        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
        Console.WriteLine(bus.ToString());
    }

    private static void DriveAndRefuel(Vehicles car, Vehicles truck, Vehicles bus)
    {
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string[] args = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string activity = args[0];
            string type = args[1];
            try
            {
                switch (activity)
                {
                    case "Drive":
                        double km = double.Parse(args[2]);
                        if (type == "Car")
                        {
                            car.DrivenAGivenDistance(km);
                        }
                        else if (type == "Truck")
                        {
                            truck.DrivenAGivenDistance(km);
                        }
                        else
                        {
                            bus.DrivenAGivenDistance(km);
                        }
                        break;
                    case "Refuel":
                        double liters = double.Parse(args[2]);
                        if (type == "Car")
                        {
                            car.RefueledVehicles(liters);
                        }
                        else if (type == "Truck")
                        {
                            truck.RefueledVehicles(liters);
                        }
                        else
                        {
                            bus.RefueledVehicles(liters);
                        }
                        break;
                    case "DriveEmpty":
                        km = double.Parse(args[2]);
                        bus.DrivenAGivenDistance(km, false);
                        break;
                }
            }
            catch(ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            
        }
    }
}


