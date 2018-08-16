using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new List<Product>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            money = value;
        }
    }

    private List<Product> BagOfProducts
    {
        get { return bagOfProducts; }
        set { bagOfProducts = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (bagOfProducts.Count == 0)
        {
            sb.Append($"{Name} - Nothing bought");
        }
        else
        {
            sb.Append($"{Name} - ");
            foreach (var product in bagOfProducts)
            {
                sb.Append($"{product.Name}, ");
            }
            sb.Remove(sb.Length - 2, 2);
        }
        return sb.ToString();
    }

    public void BuyProduct(Product product)
    {
        decimal currentMoney = Money;
        currentMoney -= product.Cost;

        if(currentMoney < 0)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} bought {product.Name}");
            Money = currentMoney;
            bagOfProducts.Add(product);
        }
    }
}

