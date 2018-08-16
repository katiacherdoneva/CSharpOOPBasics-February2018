using System;
using System.Text;

public class Program
{
    static void Main()
    {
        string[] elements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        AddElementsInCollection(elements, addCollection);
        AddElementsInCollection(elements, addRemoveCollection);
        AddElementsInCollection(elements, myList);

        int countRemoveElements= int.Parse(Console.ReadLine());
        RemoveElementsFromCollection(addRemoveCollection, countRemoveElements);
        RemoveElementsFromCollection(myList, countRemoveElements);
    }

    private static void RemoveElementsFromCollection(IRemovable addRemoveCollection, int countRemoveElements)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < countRemoveElements; i++)
        {
            sb.Append(addRemoveCollection.Remove())
                .Append(' ');
        }
        Console.WriteLine(sb.ToString().Trim());
    }

    private static void AddElementsInCollection(string[] elements, IAddable addCollection)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var e in elements)
        {
            sb.Append(addCollection.Add(e))
                .Append(' ');
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}

