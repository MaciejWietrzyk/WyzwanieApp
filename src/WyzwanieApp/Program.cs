using System;
using System.Collections.Generic;

namespace WyzwanieApp
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.Write("Enter the employee's name: ");
            var employee = new Employee(Console.ReadLine());

            string input = string.Empty;

            while (true)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Please eneter grade (1-6). You can modify grades by \"+\" or \"-\" signs for {employee.Name}.\nYou can not use -1 and +6 grades \nIf you want to quit, press 'q' and ENTER");
                Console.ForegroundColor = color;
                input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                if (!string.IsNullOrEmpty(input) && input != "q" && CheckFormat(input))
                {
                    employee.AddGrade(input);
                }
                else
                {
                    throw new FormatException("Bad Format");
                }

                employee.GetStatistics();
                Console.WriteLine("------------");
            }
        }

        public static bool CheckFormat(string text)
        {
            if (text.Length > 2)
                return false;

            foreach (char character in text)
            {
                if (character > '0' || character < '9' || character == '+' || character == '-')
                    return true;
            }

            return false;
        }

    }

}
