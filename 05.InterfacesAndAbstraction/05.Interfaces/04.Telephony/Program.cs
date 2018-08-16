using System;

public class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine()
            .Split(new[] { ' ' });
        string[] webSites = Console.ReadLine()
            .Split(new[] { ' ' });

        Smartphone smartphone = new Smartphone();
        foreach (var num in numbers)
        {
            Console.WriteLine(smartphone.Call(num));
        }

        foreach (var webSite in webSites)
        {
            Console.WriteLine(smartphone.Browse(webSite));
        }
    }
}

