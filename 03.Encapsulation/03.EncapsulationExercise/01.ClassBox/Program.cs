using System;

public class Program
{
    static void Main()
    {
        decimal[] parameters = new decimal[3];
        for (int i = 0; i < 3; i++)
        {
            parameters[i] = decimal.Parse(Console.ReadLine());
        }

        Box box = new Box(parameters[0], parameters[1], parameters[2]);
        Console.WriteLine(box.ToString());
    }
}

