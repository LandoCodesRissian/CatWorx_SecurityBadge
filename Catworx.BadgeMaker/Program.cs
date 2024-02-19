using System;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
        //Starting Employees
        List<string> employees = new List<string>();
        // Collect user values until the value is "exit"
        while (true)
        {
        Console.WriteLine("Please enter a name: (or exit to exit) ");

        //Get a name from the console and assign it a variable
        string input = Console.ReadLine() ?? "";

        // exit if answer is exit
        if (input == "exit") 
        {
            break;
        }
        employees.Add(input);
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine(employees[i]);
        }
        }
    }
  }
}