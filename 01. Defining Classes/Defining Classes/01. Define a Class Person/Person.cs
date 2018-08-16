using System;

public class Person
{
    string name;
    int age;

    public string Name
    {
        get { return name; }
        set { value = name; }
    }
    public int Age
    {
        get { return age; }
        set { value = age; }
    }

    public Person()
    {
        name = "Pesho";
        age = 20;
    }
}