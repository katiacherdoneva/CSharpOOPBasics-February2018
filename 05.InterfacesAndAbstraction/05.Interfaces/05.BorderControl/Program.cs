using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        string input;
        List<SocietyMember> citizens = new List<SocietyMember>();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            citizens.Add(CreateNewMember(info));
        }       
        PrintValidId(citizens);
    }

    private static void PrintValidId(List<SocietyMember> citizens)
    {
        string validLastDigits = Console.ReadLine();

        foreach (var c in citizens)
        {
            if(c.Id.EndsWith(validLastDigits))
            {
                Console.WriteLine(c.Id);
            }
        }
    }

    private static SocietyMember CreateNewMember(string[] info)
    {
        if (info.Length > 2)
        {
            Citizen citizen = new Citizen(info[0], int.Parse(info[1]), info[2]);
            return citizen;
        }
        Robot robot = new Robot(info[0], info[1]);
        return robot;
    }
}

