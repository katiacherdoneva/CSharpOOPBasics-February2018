﻿public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        Weight = weight;
        Type = type;
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
}

