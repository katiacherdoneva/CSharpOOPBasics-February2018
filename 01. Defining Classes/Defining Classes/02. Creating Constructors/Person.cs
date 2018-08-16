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
        Age = 1;
        Name = "No name";
    }

    public Person(int age)
    {
        Name = "No name";
        Age = age;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}