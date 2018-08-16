using System;
using System.Linq;
using System.Collections.Generic;

class SpeedRacing
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Car car = new Car(input[0], int.Parse(input[1]), decimal.Parse(input[2]));
            cars.Add(car);
        }

        while (true)
        {
            string[] commands = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if(commands[0] == "End")
            {
                break;
            }

            cars.Where(c => c.Model == commands[1]).ToList().ForEach(c => c.MoveThatDistance(decimal.Parse(commands[2])));
        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}");
        }
    }
}

