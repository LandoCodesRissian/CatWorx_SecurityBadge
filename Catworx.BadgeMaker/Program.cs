﻿using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
static List<Employee> GetEmployees()
{
    List<Employee> employees = new List<Employee>(); // Declare outside the while loop

    while (true)
    {
        // Get a name from the console and assign it to a variable
        Console.WriteLine("Please enter a first name: (or `exit` to close): ");
        string firstName = Console.ReadLine() ?? "";

        // Exit if answer is "exit"
        if (firstName == "exit")
        {
            break; // Exit the loop, but employees is still in scope
        }
        // Collect user lastName value
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine() ?? "";
        //Collect user id
        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");
        // Enter Photo URL
        Console.Write("Enter Photo URL: ");
        string photoUrl = Console.ReadLine() ?? "";
        // Create new Employee instance and add it to the list
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
    }

    return employees;
}


        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName, employees[i].GetPhotoUrl()));
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}
