using System;

namespace CatWorx.BadgeMaker
{
  class Program
{
  static List<string> GetEmployees()
  {
    // Collect user values until the value is "exit"
    List<string> employees = new List<string>();
    while (true)
    {

      // Get a name from the console and assign it to a variable
      Console.WriteLine("Please enter a name: (or `exit` to close): ");
      string input = Console.ReadLine() ?? "";

      //Exit if answer is exit
      if (input == "exit")
      {
        break;
      }
      employees.Add(input);
    }
    return employees;
  }

  static void PrintEmployees(List<string> employees)
  {
    for (int i = 0; i < employees.Count; i++)
    {
      Console.WriteLine(employees[i]);
    }
  }

  static void Main(string[] args)
  {
    List<string> employees = GetEmployees();
    PrintEmployees(employees);
  }
}
}