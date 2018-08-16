using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string Browse(string webSite)
    {
        if (webSite.Any(x => char.IsDigit(x)))
            return"Invalid URL!";
        return $"Browsing: {webSite}!";
    }

    public string Call(string number)
    {
        if (number.All(x => !char.IsDigit(x)))
            return "Invalid number!";
        return $"Calling... {number}";
    }
}

