using System.Text;

public class SpecialiseSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialiseSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public string Corps
    {
        get { return corps; }
        set { corps = value; }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder
            .AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps}");

        return builder.ToString().Trim();
    }
}

