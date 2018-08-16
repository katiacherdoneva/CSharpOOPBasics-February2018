using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Animal animal = GetAnimal(command);
                Console.WriteLine(animal.MakeSound());
                animals.Add(animal);

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food food = GetFood(command);
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        PrintAnimal(animals);
    }

    private static void PrintAnimal(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    private static Food GetFood(string[] command)
    {
        int quantity = int.Parse(command[1]);

        Food food = null;
        switch (command[0])
        {
            case "Vegetable":
                food = new Vegetable(quantity);
                break;
            case "Fruit":
                food = new Fruit(quantity);
                break;
            case "Meat":
                food = new Meat(quantity);
                break;
            case "Seeds":
                food = new Seeds(quantity);
                break;
        }
        return food;
    }

    private static Animal GetAnimal(string[] command)
    {
        Animal animal = null;
        switch (command[0])
        {
            case "Cat":
                animal = new Cat(command[1], double.Parse(command[2]), command[3], command[4]);
                break;
            case "Tiger":
                animal = new Tiger(command[1], double.Parse(command[2]), command[3], command[4]);
                break;
            case "Hen":
                animal = new Hen(command[1], double.Parse(command[2]), double.Parse(command[3]));
                break;
            case "Owl":
                animal = new Owl(command[1], double.Parse(command[2]), double.Parse(command[3]));
                break;
            case "Mouse":
                animal = new Mouse(command[1], double.Parse(command[2]), command[3]);
                break;
            case "Dog":
                animal = new Dog(command[1], double.Parse(command[2]), command[3]);
                break;
        }
        return animal;
    }
}

