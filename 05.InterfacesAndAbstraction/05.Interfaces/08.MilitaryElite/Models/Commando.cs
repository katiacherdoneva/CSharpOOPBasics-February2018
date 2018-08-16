using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialiseSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName,
       double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<Mission>();
    }
    public List<Mission> Missions { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Missions:");

        foreach (var m in Missions)
        {
            sb.AppendLine(m.ToString());
        }

        return sb.ToString().Trim();
    }
}

