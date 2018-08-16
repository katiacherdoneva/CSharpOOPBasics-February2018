using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    static void Main(string[] args)
    {
        long capacityOnBag = long.Parse(Console.ReadLine());
        string[] itemQuantityPairs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();

        long gold = 0;
        long gems = 0;
        long cash = 0;
        for (int i = 0; i < itemQuantityPairs.Length; i += 2)
        {
            string name = itemQuantityPairs[i];
            long quantity = long.Parse(itemQuantityPairs[i + 1]);

            string item = string.Empty;
            item = GetItem(name, item);

            if (item == "")
            {
                continue;
            }
            else if (capacityOnBag < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
            {
                continue;
            }

            bool isFull = false;
            string nextItem;
            switch (item)
            {
                case "Gem":
                    nextItem = "Gold";
                    isFull = isFull = NewMethod(bag, quantity, item, isFull);
                    break;
                case "Cash":

                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (quantity > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[item].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            CreatеBag(bag, item);

            FullQuantityInItem(bag, name, quantity, item);

            FullFieldItem(ref gold, ref gems, ref cash, quantity, item);
        }

        PrintBag(bag);
    }

    private static bool NewMethod(Dictionary<string, Dictionary<string, long>> bag, long quantity, string item, bool isFull)
    {
        if (!bag.ContainsKey(item))
        {
            if (bag.ContainsKey("Gold"))
            {
                if (quantity > bag["Gold"].Values.Sum())
                {
                    isFull = true;
                }
            }
            else
            {
                isFull = true;
            }
        }
        else if (bag[item].Values.Sum() + quantity > bag["Gold"].Values.Sum())
        {
            isFull = true;
        }

        return isFull;
    }

    private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var item in bag)
        {
            Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
            foreach (var typeItem in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{typeItem.Key} - {typeItem.Value}");
            }
        }
    }

    private static void FullQuantityInItem(Dictionary<string, Dictionary<string, long>> bag, string name, long quantity, string item)
    {
        if (!bag[item].ContainsKey(name))
        {
            bag[item][name] = 0;
        }
        bag[item][name] += quantity;
    }

    private static void CreatеBag(Dictionary<string, Dictionary<string, long>> bag, string item)
    {
        if (!bag.ContainsKey(item))
        {
            bag[item] = new Dictionary<string, long>();
        }
    }

    private static void FullFieldItem(ref long gold, ref long gems, ref long cash, long quantity, string item)
    {
        if (item == "Gold")
        {
            gold += quantity;
        }
        else if (item == "Gem")
        {
            gems += quantity;
        }
        else if (item == "Cash")
        {
            cash += quantity;
        }
    }

    private static string GetItem(string name, string item)
    {
        if (name.Length == 3)
        {
            item = "Cash";
        }
        else if (name.ToLower().EndsWith("gem"))
        {
            item = "Gem";
        }
        else if (name.ToLower() == "gold")
        {
            item = "Gold";
        }

        return item;
    }
}
