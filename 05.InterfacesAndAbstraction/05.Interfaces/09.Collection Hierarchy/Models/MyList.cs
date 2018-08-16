using System.Collections.Generic;

public class MyList : IAddable, IRemovable, ICountable
{
    public MyList()
    {
        Collection = new List<string>();
    }

    public List<string> Collection;

    public int Used => Collection.Count;

    public int Add(string element)
    {
        Collection.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string firstElement = Collection[0];
        Collection.RemoveAt(0);
        return firstElement;
    }
}

