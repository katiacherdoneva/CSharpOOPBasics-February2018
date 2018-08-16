using System.Collections.Generic;

public class AddRemoveCollection : IAddable, IRemovable
{
    public AddRemoveCollection()
    {
        Collection = new List<string>();
    }

    public List<string> Collection { get; set; }

    public int Add(string element)
    {
        Collection.Insert(0, element);
        return 0;

    }

    public string Remove()
    {
        string lastElement = Collection[Collection.Count - 1];
        Collection.RemoveAt(Collection.Count - 1);
        return lastElement;
    }
}

