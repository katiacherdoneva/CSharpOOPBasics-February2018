using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    private static List<Person> people = new List<Person>();
    private static List<Product> products = new List<Product>();

    static void Main()
    {
        string[] inputPeople = Console.ReadLine()
           .Split(';', StringSplitOptions.RemoveEmptyEntries);
        string[] inputProducts = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputPeople.Length; i++)
        {
            int index = 0;
            string[] infoForPerson = inputPeople[i].Split("=");
            string[] infoForProduct = inputProducts[i].Split("=");

            Person person;
            Product product;
            try
            {
                person = new Person(infoForPerson[index], decimal.Parse(infoForPerson[index + 1]));
                product = new Product(infoForProduct[index], decimal.Parse(infoForProduct[index + 1]));
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                return;
            }

            people.Add(person);
            products.Add(product);
            index += 2;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                CurrentPersonBuyProduct(command);
            }

            Console.WriteLine(string.Join("\r\n", people.Select(x => x.ToString())));
        }
    }

    private static void CurrentPersonBuyProduct(string command)
    {
        string[] infoForPerson = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

        Person currentPerson = people.FirstOrDefault(x => x.Name == infoForPerson[0]);
        Product currentProduct = products.FirstOrDefault(x => x.Name == infoForPerson[1]);


        currentPerson.BuyProduct(currentProduct);
    }
}

