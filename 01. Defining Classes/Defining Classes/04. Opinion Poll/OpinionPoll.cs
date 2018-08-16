using System;
using System.Collections.Generic;
using System.Linq;

public class OpinionPoll
{
    static void Main()
    {
        var people = new List<Person>();

        var numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personalInfo = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var person = new Person()
            {
                Name = personalInfo[0],
                Age = int.Parse(personalInfo[1])
            };

            people.Add(person);
        }

        var result = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

        foreach (var person in result)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}