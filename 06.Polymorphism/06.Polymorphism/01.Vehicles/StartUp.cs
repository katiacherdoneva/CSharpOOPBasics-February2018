using System;

public class StartUp
{
    static void Main()
    {
        var carInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var truckInfo = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        DriveAndRefuel(car, truck);
        PrintFuelOnVehicles(car, truck);
    }

    private static void PrintFuelOnVehicles(Car car, Truck truck)
    {
        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
    }

    private static void DriveAndRefuel(Vehicles car, Vehicles truck)
    {
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string[] args = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string activity = args[0];
            string type = args[1];

            switch (activity)
            {
                case "Drive":
                    double km = double.Parse(args[2]);
                    if (type == "Car")
                    {
                        Console.WriteLine(car.DrivenAGivenDistance(km));
                    }
                    else
                    {
                        Console.WriteLine(truck.DrivenAGivenDistance(km));
                    }
                    break;
                case "Refuel":
                    double liters = double.Parse(args[2]);
                    if (type == "Car")
                    {
                        car.RefueledVehicles(liters);
                    }
                    else
                    {
                        truck.RefueledVehicles(liters);
                    }
                    break;
            }
        }
    }
}


