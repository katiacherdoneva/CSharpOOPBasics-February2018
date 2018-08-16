﻿using System;

class Chicken
{
    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        Name = name;
        Age = age;
    }

    private string Name
    {
        get { return name; }
        set
        {
            if (value == string.Empty || value == null || value == " ")
                throw new ArgumentException("Name cannot be empty.");
            name = value;
        }
    }

    private int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 15)
                throw new ArgumentException("Age should be between 0 and 15.");
            age = value;
        }
    }

    public double ProductPerDay()
    {
        return this.CalculateProductPerDay();
    }

    private double CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }

    public override string ToString()
    {
        return $"Chicken {Name} (age {Age}) can produce {ProductPerDay()} eggs per day.";
    }
}
