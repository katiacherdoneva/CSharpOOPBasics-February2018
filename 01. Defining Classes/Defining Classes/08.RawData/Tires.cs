using System.Collections.Generic;

public class Tires
{
    private List<int> ages;
    private List<double> pressures;

    public Tires()
    {
        Ages = new List<int>();
        Pressures = new List<double>();
    }

    public List<int> Ages
    {
        get { return ages; }
        set { ages = value; }
    }

    public List<double> Pressures
    {
        get { return pressures; }
        set { pressures = value; }
    }   
}

