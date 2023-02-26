using System;
using System.Collections.Generic;
using System.IO;

namespace WyzwanieApp
{

    public class Employee : EmployeeBase
    {
        public delegate void LowerGradeDelegate(object sender, EventArgs args);

        private const string filename = "Grades.txt";

        public override event LowerGradeDelegate LowerGrade;
        private List<double> grades = new List<double>();

        private string name;

        public Employee(string name) : base(name)
        {
        }
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Name can not be empty");
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name} {filename}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine($"The average is: {result.Average:N2}");
            Console.WriteLine($"The the highest number is: {result.High:N2}");
            Console.WriteLine($"The the lowest number is: {result.Low:N2}");

            return result;
        }
        public override void AddPlusMinusGrade(string plusminusgrade)
        {
            throw new NotImplementedException();
        }
    }
}