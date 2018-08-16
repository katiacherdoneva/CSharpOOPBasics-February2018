using System;

public class Citizen : SocietyMember, ICitizen, IBirthdate
{
    public Citizen(string name, int age, string id, string birthdate) : base(id)
    {
        Name = name;
        Age = age;
        Birthdate = birthdate;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Birthdate { get; set; }
}

