using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        static public List<Employee> GetEmployees()
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

async public static Task<List<Employee>> GetFromApi()
{
    List<Employee> employees = new List<Employee>();

    using (HttpClient client = new HttpClient())
    {
        string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        JObject json = JObject.Parse(response);

        JArray results = (JArray)json["results"]!;

        foreach (JObject person in results)
        {
            // Extracting first name, last name, and photo URL
            string firstName = person.SelectToken("name.first")!.ToString();
            string lastName = person.SelectToken("name.last")!.ToString();
            string photoUrl = person.SelectToken("picture.large")!.ToString();

            // Extracting and converting ID
            // Note: The ID conversion logic might need adjustment based on the actual ID format in your JSON
            string idString = person.SelectToken("id.value")!.ToString().Replace("-", "");
            int id = 0;
            bool idParseResult = Int32.TryParse(idString, out id);
            if (!idParseResult)
            {
                Console.WriteLine($"Warning: Unable to parse ID for {firstName} {lastName}. Defaulting to 0.");
            }

            // Creating a new Employee object
            Employee employee = new Employee(firstName, lastName, id, photoUrl);

            // Adding the new Employee to the list
            employees.Add(employee);
        }
    }

    return employees;
}

    }
}