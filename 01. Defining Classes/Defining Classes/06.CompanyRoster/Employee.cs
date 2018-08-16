using System;

public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string email;
    private int age;

    public Employee()
    {
        email = "n/a";
        age = -1;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

}

