using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<Private>();
    }

    public List<Private> Privates { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Privates:");

        foreach (var p in Privates)
        {
            sb.AppendLine(p.ToString());
        }

        return sb.ToString().Trim();
    }
}

