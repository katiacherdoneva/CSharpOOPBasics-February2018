using System;
using System.Linq;

public class OldestFamilyMember
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int age = int.Parse(input[1]);
            string name = input[0];

            Person person = new Person(name, age);
            family.AddMember(person);
        }
        Console.WriteLine(family.GetOldestMember());
    }
}

