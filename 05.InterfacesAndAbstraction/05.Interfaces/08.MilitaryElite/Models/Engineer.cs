using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecialiseSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName,
        double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<Repair>();
    }
    public List<Repair> Repairs { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Repairs:");

        foreach (var r in Repairs)
        {
            sb.AppendLine(r.ToString());
        }

        return sb.ToString().Trim();
    }
}

