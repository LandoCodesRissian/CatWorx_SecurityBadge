using System;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      string greeting = "Hello!";
      greeting = greeting + "World";
      Console.WriteLine("greeting: " + greeting);
      Console.WriteLine($"greeting: {greeting}"); 
      Console.WriteLine("greeting: {0}", greeting);
      
      // How do you find the area of a square? Area = side * side
        float side = 3.14F;
        float area = side * side;
        Console.WriteLine("area: {0}", area);

        double edge = 3.14;
        double total = edge * edge;
        Console.WriteLine("Total: {0}", total);

        Console.WriteLine("area is a {0}", area.GetType());



        Console.WriteLine(2 * 3);         // Basic Arithmetic: +, -, /, * =6
Console.WriteLine(10 % 3);        // Modulus Op => remainder of 10/3 =1
Console.WriteLine(1 + 2 * 3);     // order of operations =7
Console.WriteLine(10 / 3.0);      // int's and doubles =
Console.WriteLine(10 / 3);        // int's  =3
Console.WriteLine("12" + "3");    // What happens here? =Nothing will show 123

int num = 10;
num += 100;
Console.WriteLine(num);
num ++;
Console.WriteLine(num);

bool isCold = true;
Console.WriteLine(isCold ? "drink" : "add ice");  // output: drink
Console.WriteLine(!isCold ? "drink" : "add ice");  // output: add ice

string stringNum = "2";
int intNum = Convert.ToInt32(stringNum);
Console.WriteLine(intNum);
Console.WriteLine(intNum.GetType());
    }
  }
}