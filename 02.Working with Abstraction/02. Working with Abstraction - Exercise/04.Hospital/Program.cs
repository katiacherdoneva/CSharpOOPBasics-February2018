using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

        string command;
        while ((command = Console.ReadLine()) != "Output")
        {
            string[] infoForHospital = command.Split(); //department, doctors and patients
            var department = infoForHospital[0];
            var firstName = infoForHospital[1];
            var secondName = infoForHospital[2];
            var patient = infoForHospital[3];
            var fullName = firstName + secondName;

            doctors = GetDoctors(doctors, firstName, secondName, fullName);
            departments = GetDepartament(departments, department);

            departments = FullRoom(doctors, departments, department, patient, fullName);
        }

        while ((command = Console.ReadLine()) != "End")
        {
            PrintInfoForHospital(doctors, departments, command);
        }
    }

    private static void PrintInfoForHospital(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] args = command.Split();

        if (args.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (args.Length == 2 && int.TryParse(args[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
        }
    }

    private static Dictionary<string, List<List<string>>> FullRoom(Dictionary<string, List<string>> doctors, 
                                                                   Dictionary<string, List<List<string>>> departments, 
                                                                   string department, string patient, string fullName)
    {
        bool isHasFreeBed = departments[department].SelectMany(x => x).Count() < 60;
        if (isHasFreeBed)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int r = 0; r < departments[department].Count; r++)
            {
                if (departments[department][r].Count < 3)
                {
                    room = r;
                    break;
                }
            }
            departments[department][room].Add(patient);
        }
        return departments;
    }

    private static Dictionary<string, List<List<string>>> GetDepartament(Dictionary<string, List<List<string>>> departments,
                                                                         string department)
    {
        if (!departments.ContainsKey(department))
        {
            departments[department] = new List<List<string>>();
            for (int stai = 0; stai < 20; stai++)
            {
                departments[department].Add(new List<string>());
            }
        }

        return departments;
    }

    private static Dictionary<string, List<string>> GetDoctors(Dictionary<string, List<string>> doctors, 
        string firstName, string secondName, string fullName)
    {
        if (!doctors.ContainsKey(firstName + secondName))
        {
            doctors[fullName] = new List<string>();
        }

        return doctors;
    }
}
