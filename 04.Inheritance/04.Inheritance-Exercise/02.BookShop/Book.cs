﻿using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string authos, string title, decimal price)
    {
        Title = title;
        Author = authos;
        Price = price;
    }

    public virtual string Author
    {
        get { return author; }
        set
        {
            string[] names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 1 &&
                    char.IsDigit(names[1][0]))
                throw new ArgumentException("Author not valid!");
            author = value;
        }
    }

    public virtual string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");
            price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {GetType().Name}")
                     .AppendLine($"Title: {this.Title}")
                     .AppendLine($"Author: {this.Author}")
                     .AppendLine($"Price: {this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();

        return result;
    }
}

