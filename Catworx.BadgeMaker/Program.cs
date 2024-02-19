using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static List<Employee> GetEmployees()
        {
            // Collect user values until the value is "exit"
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                // Get a name from the console and assign it to a variable
                Console.WriteLine("Please enter a name: (or `exit` to close): ");
                string input = Console.ReadLine() ?? "";

                // Exit if answer is exit
                if (input == "exit")
                {
                    break;
                }
                // Create new Employee instance
                Employee currentEmployee = new Employee(input, "Smith");
                employees.Add(currentEmployee);
            }
            return employees;
        }

        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].GetFullName());
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}
