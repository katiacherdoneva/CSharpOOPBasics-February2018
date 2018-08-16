using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        try
        {
            Pizza pizza = CreatePizzaWithDough();

            AddTopping(pizza);
            double sum = pizza.SumOfCalories();
            Console.WriteLine(pizza.ToString());
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
            return;
        }
       
    }

    private static void AddTopping(Pizza pizza)
    {
        string command;
        while((command = Console.ReadLine()) != "END")
        {
            string[] infoFortopping = command.Split(' ');

            Topping topping = new Topping(infoFortopping[1], double.Parse(infoFortopping[2]));

            pizza.AddTopping(topping);
        }
    }

    private static Pizza CreatePizzaWithDough()
    {
        Pizza pizza = new Pizza();

        string[] nameOfPizza = Console.ReadLine()
                      .Split(" ")
                      .ToArray();
        pizza.Name = nameOfPizza[1];

        string[] infoForDough = Console.ReadLine()
              .Split(" ")
              .ToArray();
        Dough dough = new Dough(infoForDough[1], infoForDough[2], double.Parse(infoForDough[3]));
        pizza.Dough = dough;

        return pizza;
    }
}

