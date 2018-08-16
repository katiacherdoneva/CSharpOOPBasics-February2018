using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            cars.Add(Car.NewCar(parameters));
        }

        string command = Console.ReadLine();
        Console.WriteLine(ResultByCommand(cars, command));  
    }

    private static string ResultByCommand(List<Car> cars, string command)
    {
        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                .Select(x => x.model)
                .ToList();

            return string.Join(Environment.NewLine, fragile);
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                .Select(x => x.model)
                .ToList();

           return string.Join(Environment.NewLine, flamable);
        }
    }
}


