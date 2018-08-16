using System;

public class Citizen:SocietyMember, ICitizen
{
    public Citizen(string name, int age, string id) : base(id)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }
}

