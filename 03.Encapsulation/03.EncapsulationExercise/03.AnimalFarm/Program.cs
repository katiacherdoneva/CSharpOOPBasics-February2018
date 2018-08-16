using System;

public class Program
{
    static void Main()
    {
        string name = string.Empty;
        int age;

        string input = Console.ReadLine();
        bool isName = int.TryParse(input, out age);
        if (!isName)
        {
            name = input;
            age = int.Parse(Console.ReadLine());
        }

        try
        {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(chicken.ToString());
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }

    }
}

