using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        List<IBirthdate> members = GetListOfMembers();

        PrintValidYears(members);
    }

    private static void PrintValidYears(List<IBirthdate> members)
    {
        string validYear = Console.ReadLine();
        foreach (var m in members)
        {
            if (m.Birthdate.EndsWith(validYear))
            {
                Console.WriteLine(m.Birthdate);
            }
        }
    }

    private static List<IBirthdate> GetListOfMembers()
    {
        List<IBirthdate> members = new List<IBirthdate>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string memberType = info[0];
            switch (memberType)
            {
                case "Pet":
                    members.Add(new Pet(info[1], info[2]));
                    break;
                case "Citizen":
                    members.Add(new Citizen(info[1], int.Parse(info[2]), info[3], info[4]));
                    break;
            }
        }

        return members;
    }
}

