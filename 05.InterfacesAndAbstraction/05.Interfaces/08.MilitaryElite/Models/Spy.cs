using System.Text;

public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public int CodeNumber { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Code Number: {CodeNumber}");
        return sb.ToString().Trim();
    }
}

