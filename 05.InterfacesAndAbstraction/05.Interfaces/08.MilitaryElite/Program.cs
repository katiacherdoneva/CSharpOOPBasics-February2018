using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Soldier> soldiers = GetSoldiers();
        PrintSoldiers(soldiers);
    }

    private static void PrintSoldiers(List<Soldier> soldiers)
    {
        foreach (var s in soldiers)
        {
            Console.WriteLine(s.ToString());
        }
    }

    private static List<Soldier> GetSoldiers()
    {
        List<Soldier> soldiers = new List<Soldier>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string soldierType = info[0];
            switch (soldierType)
            {
                case "Private":
                    soldiers.Add(new Private(info[1], info[2], info[3], double.Parse(info[4])));
                    break;
                case "LeutenantGeneral":
                    LeutenantGeneral leutenantGeneral = new LeutenantGeneral(info[1], info[2], info[3], double.Parse(info[4]));
                    var privatesIds = info.Skip(5);
                    foreach (var privateId in privatesIds)
                    {
                        var priv = (Private)soldiers.FirstOrDefault(s => s.Id == privateId);
                        leutenantGeneral.Privates.Add(priv);
                    }
                    soldiers.Add(leutenantGeneral);
                    break;
                case "Engineer":
                    if (!IsValidCorps(info[5]))
                    {
                        continue;
                    }
                    Engineer engineer = new Engineer(info[1], info[2], info[3], double.Parse(info[4]), info[5]);
                    for (int i = 6; i < info.Length; i+=2)
                    {
                        engineer.Repairs.Add(new Repair(info[i], int.Parse(info[i + 1])));
                    }
                    soldiers.Add(engineer);
                    break;
                case "Commando":
                    if(!IsValidCorps(info[5]))
                    {
                        continue;
                    }
                    Commando commando = new Commando(info[1], info[2], info[3], double.Parse(info[4]), info[5]);
                    for (int i = 6; i < info.Length; i+=2)
                    {
                        if(info[i + 1] == "inProgress" || info[i + 1] == "Finished")
                        {
                            commando.Missions.Add(new Mission(info[i], info[i + 1]));
                        }
                    }
                    soldiers.Add(commando);
                    break;
                case "Spy":
                    soldiers.Add(new Spy(info[1], info[2], info[3], int.Parse(info[4])));
                    break;
            }
        }
        return soldiers;
    }

    private static bool IsValidCorps(string corps)
    {
        if (corps == "Airforces" || corps == "Marines")
        {
            return true;
        }
        return false;
    }
}

