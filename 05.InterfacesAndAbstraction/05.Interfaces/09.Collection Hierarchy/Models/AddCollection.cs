using System.Collections.Generic;

public class AddCollection : IAddable
{
    public AddCollection()
    {
        Collections = new List<string>();
    }

    public List<string> Collections {get; set;}

    public int Add(string element)
    {
        Collections.Add(element);
        return Collections.Count - 1;
    }
}

