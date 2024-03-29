﻿﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        //Code to Print Employees to cmd
        public static void PrintEmployees(List<Employee> employees) {
            for (int i=0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }

        // Code to make the CSV
        public static void MakeCSV(List<Employee> employees) 
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoURl");
                
                // Loop over and write each employee to the file
                for (int i=0; i < employees.Count; i++)
                {
                string template = "{0,-10}\t{1,-20}\t{2}";
                file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }

        // Code to make the actual badges
        async public static Task MakeBadges(List<Employee> employees) 
        {
            // Layout variables for badge
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;

            int COMPANY_NAME_Y = 150;

            int EMPLOYEE_NAME_Y = 600;

            int EMPLOYEE_ID_Y = 730;
            // instance of HttpClient is disposed after code in the block has run
            using(HttpClient client = new HttpClient())
            {
            for (int i = 0; i < employees.Count; i++) 
            {
                SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                SKCanvas canvas = new SKCanvas(badge);

                canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                SKPaint paint = new SKPaint();
                paint.TextSize = 42.0f;
                paint.IsAntialias = true;
                paint.Color = SKColors.White;
                paint.IsStroke = false;
                paint.TextAlign = SKTextAlign.Center;
                paint.Typeface = SKTypeface.FromFamilyName("Arial");

                // Company name
                canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);

                paint.Color = SKColors.Black;

                // Employee name
                canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);

                paint.Typeface = SKTypeface.FromFamilyName("Courier New");

                // Employee ID
                canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);

                SKImage finalImage = SKImage.FromBitmap(badge);
                SKData data = finalImage.Encode();
                string template = "data/{0}_badge.png";
                data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));
                // SKData data = background.Encode();
                // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
            }
            }
        }
    }
    class Program
    {
        static async Task Main(string[] args)
  {
            List<Employee> employees = new List<Employee>();
            bool isRunning = true;

            while (isRunning)
            {
                // Presnt user with choises
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1: Enter data manually");
                Console.WriteLine("2: Get random data from API");
                Console.WriteLine("3: Exit");
                Console.Write("Your choice: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        employees = PeopleFetcher.GetEmployees();
                        break;
                    case "2":
                        employees = await PeopleFetcher.GetFromApi();
                        break;
                    case "3":
                        isRunning = false;
                        Console.WriteLine("Exiting...");
                        continue;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        continue;
                }

                if (employees.Count > 0)
                {
                    Util.PrintEmployees(employees);
                    Util.MakeCSV(employees);
                    await Util.MakeBadges(employees);
                }
                else
                {
                    Console.WriteLine("No employees to process.");
                }
            }
        }
    }
}