public class Private : Soldier, IPrivate
{
   private double salary;

    public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {salary:f2}";
    }
}

