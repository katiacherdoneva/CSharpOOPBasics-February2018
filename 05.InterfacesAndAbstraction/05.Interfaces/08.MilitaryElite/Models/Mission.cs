public class Mission : IMission
{
    public Mission(string name, string state)
    {
        Name = name;
        State = state;
    }
    public string Name { get; set; }

    public string State { get; set; }

    public void CompleteMission()
    {
        State = "Finished";
    }

    public override string ToString()
    {
        return $"  Code Name: {Name} State: {State}";
    }
}

