using System;

public class DateModifier
{
    private DateTime dateFirst;

    public DateTime DateFirst
    {
        get { return dateFirst; }
        set { dateFirst = value; }
    }

    private DateTime dateSecond;

    public DateTime DateSecond
    {
        get { return dateSecond; }
        set { dateSecond = value; }
    }

    public double DaysDiff(DateTime dateFirst, DateTime dateSecond)
    {
        return Math.Abs((DateSecond - DateFirst).TotalDays);
    }
}
