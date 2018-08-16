using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Department> departments = new List<Department>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Employee employee = new Employee()
            {
                Name = input[0],
                Salary = decimal.Parse(input[1]),
                Position = input[2],
            };

            if(input.Length == 5)
            {
                if(input[4].Contains('@'))
                {
                    employee.Email = input[4];
                }
                else
                {
                    employee.Age = int.Parse(input[4]);
                }
            }
            else if(input.Length == 6)
            {
                employee.Email = input[4];
                employee.Age = int.Parse(input[5]);
            }

            if (!departments.Any(d => d.Name == input[3]))
            {
                Department dep = new Department();
                dep.Name = input[3];
                departments.Add(dep);
            }
            var department = departments.FirstOrDefault(d => d.Name == input[3]);

            department.Employees.Add(employee);
        }

        Console.WriteLine($"Highest Average Salary: {departments.OrderByDescending(x => x.AverageSalary).First().Name}");

        foreach (var e in departments.OrderByDescending(x => x.AverageSalary).First().Employees.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}");
        }
    }
}

