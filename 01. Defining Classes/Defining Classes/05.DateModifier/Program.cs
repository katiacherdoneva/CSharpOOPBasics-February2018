using System;
using System.Globalization;

public class Program
{
    static void Main()
    {
        DateModifier date = new DateModifier();
        date.DateFirst = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", DateTimeFormatInfo.InvariantInfo);
        date.DateSecond = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", DateTimeFormatInfo.InvariantInfo);

        Console.WriteLine(date.DaysDiff(date.DateFirst, date.DateSecond));
    }
}
