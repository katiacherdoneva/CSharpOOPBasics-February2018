using System;

public class Person
{
    string name;
    int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public Person()
    {
        age = 1;
        name = "No name";
    }

    public Person(int age)
    {
        name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

