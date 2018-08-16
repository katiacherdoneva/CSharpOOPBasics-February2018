using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    List<Person> persons;

    public List<Person> Persons
    {
        get { return persons; }
        set { persons = value; }
    }

    public Family()
    {
        persons = new List<Person>();
    }

    public void AddMember(Person person)
    {
        persons.Add(person);
    }

    public string GetOldestMember()
    {
        Person person = Persons.OrderByDescending(x => x.Age).First();

        return person.Name + " " + person.Age;
    }
}

