using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<IBuyer> buyers = GetBuyers();

        int totalFood = GetTotalFood(buyers);

        Console.WriteLine(totalFood);
    }

    private static int GetTotalFood(List<IBuyer> buyers)
    {
        int totalFood = 0;
        string input;
        while((input = Console.ReadLine()) != "End")
        {
            string name = input;

            if(buyers.Any(x => x.Name == name))
            {
                IBuyer buyer = buyers.FirstOrDefault(x => x.Name == name);
                buyer.BuyFood();
                totalFood += buyer.Food;
            }
        }
        return totalFood;
    }

    private static List<IBuyer> GetBuyers()
    {
        List<IBuyer> buyers = new List<IBuyer>();
        int numbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numbers; i++)
        {
            string[] info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (info.Length)
            {
                case 3:
                    buyers.Add(new Rebel(info[0], int.Parse(info[1]), info[2]));
                    break;
                case 4:
                    buyers.Add(new Citizen(info[0], int.Parse(info[1]), info[2], info[3]));
                    break;
            }
        }
        return buyers;
    }
}

