using System;

class Program
{
    static void Main()
    {
        string type;
        while((type = Console.ReadLine()) != "Beast!")
        {
            try
            {
                Animal animal = GetAnimal(type);
                Console.Write(animal.ToString());
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
        
    }

    private static Animal GetAnimal(string type)
    {
        string[] input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string name = input[0];
        int age = int.Parse(input[1]);
        string gender = input[2];

        switch (type)
        {
            case "Dog":
                return new Dog(name, age, gender);
            case "Cat":
                return new Cat(name, age, gender);
            case "Frog":
                return new Frog(name, age, gender);
            case "Kitten":
                return new Kitten(name, age);
            case "Tomcat":
                return new Tomcat(name, age);
            default: throw new ArgumentException("Invalid input!");
        }
    }
}

