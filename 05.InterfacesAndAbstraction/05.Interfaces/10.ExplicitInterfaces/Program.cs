using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Citizen> citizens = GetCitizen();

        PrintGetName(citizens);
    }

    private static void PrintGetName(List<Citizen> citizens)
    {
        foreach (var c in citizens)
        {
            Console.WriteLine(((IPerson)c).GetName());
            Console.WriteLine(((IResident)c).GetName());
        }
    }

    private static List<Citizen> GetCitizen()
    {
        List<Citizen> citizens = new List<Citizen>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Citizen citizen = new Citizen(info[0], info[1], int.Parse(info[2]));
            citizens.Add(citizen);
        }
        return citizens;
    }
}
