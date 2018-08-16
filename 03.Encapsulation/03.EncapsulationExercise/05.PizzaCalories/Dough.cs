using System;

public class Dough
{
    private string frourType;
    private string bakingTechnique;
    private double weight;
    private const double caloriesPerGram = 2;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FrourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FrourType
    {
        get { return frourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            frourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                throw new ArgumentException("Invalid type of dough.");
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            weight = value;
        }
    }

    public double Callories()
    {
        double modifier = caloriesPerGram;
        switch (FrourType.ToLower())
        {
            case "white": modifier *= 1.5; break;
            case "wholegrain": modifier *= 1.0; break;
        }

        switch (this.BakingTechnique.ToLower())
        {
            case "crispy": modifier *= 0.9; break;
            case "chewy": modifier *= 1.1; break;
            case "homemade": modifier *= 1.0; break;
        }

        return modifier * this.Weight;
    }
}


