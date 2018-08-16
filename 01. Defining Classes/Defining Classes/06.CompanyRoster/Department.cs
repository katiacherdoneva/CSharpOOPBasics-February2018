using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees;
    string name;

    public Department()
    {
        this.Employees = new List<Employee>();
        Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        set { employees = value; }
    }

    public decimal AverageSalary => this.Employees.Select(e => e.Salary).Average();
}

