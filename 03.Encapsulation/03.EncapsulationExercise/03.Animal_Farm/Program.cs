using System;

class Program
{
    static void Main()
    {
        string name = " ";
        int age;

        string input = Console.ReadLine();
        bool isAge = int.TryParse(input, out age);
        if (!isAge)
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
