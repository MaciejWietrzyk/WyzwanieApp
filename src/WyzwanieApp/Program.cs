using System;
using System.Collections.Generic;

namespace WyzwanieApp
{
    class Program
    {
        public static SavedEmployee save;
        static void Main(string[] args)
        {

            Console.Write("Enter the employee's name: ");
            var employee = new Employee(Console.ReadLine());
            save = new SavedEmployee(employee.Name);

            employee.LowerGrade += OnLowGrade;
            static void OnLowGrade(object sender, EventArgs args)

            {
                Console.WriteLine("Oh, no! We should inform boss about this fact");
            }

            string input = string.Empty;
            while (true)
            {
                Console.WriteLine($"Please eneter grade for {employee.Name}. If you want to quit, press 'q' and ENTER");
                input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                if (!string.IsNullOrEmpty(input) && input != "q")
                    save.SaveGrade(input);

                save.GetStatistics();
                Console.WriteLine("------------");
            }

        }

    }

}
