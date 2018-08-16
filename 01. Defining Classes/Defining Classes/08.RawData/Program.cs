using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = input[0];
            Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
            Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
            Tires tire = new Tires();

            int startIndex = 5;
            for (int tires = 1; tires <= 6; tires++)
            {
                if (tires % 2 == 0)
                {
                    tire.Ages.Add(int.Parse(input[startIndex]));

                }
                else
                {
                    tire.Pressures.Add(double.Parse(input[startIndex]));
                }
                startIndex++;
            }
            Car car = new Car(model, engine, cargo, tire);
            cars.Add(car);
        }

        string cargoType = Console.ReadLine();
        switch (cargoType)
        {
            case "fragile":
                foreach (var c in cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Pressures.Any(y => y < 1)))
                {
                    Console.WriteLine(c.Model);
                }
                    break;
            case "flamable":
                foreach (var c in cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(c.Model);
                }
                break;
        }
    }
}

