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
        private SavedEmployee save = new SavedEmployee();

        private string name;

        public Employee(string name) : base(name)
        {
            LowerGrade += Employee_LowerGrade;
        }

        private void Employee_LowerGrade(object sender, EventArgs args)
        {
            Console.WriteLine("Oh, no! We should inform boss about this fact");
        }

        public void AddGrade(string grade)
        {
            AddPlusMinusGrade(grade);
            save.SaveGrade(Name, GradeConversion(grade));
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
            var grade = GradeConversion(plusminusgrade);

            grades.Add(grade);

            if (LowerGrade != null && grade < 3)
            {
                LowerGrade(this, new EventArgs());
            }

        }

        private double GradeConversion(string plusminusgrade)
        {
            double grade = 0.0;

            grade = plusminusgrade switch
            {
                "1+" or "+1" => 1.5,
                "2+" or "+2" => 2.5,
                "3+" or "+3" => 3.5,
                "4+" or "+4" => 4.5,
                "5+" or "+5" => 5.5,
                "2-" or "-2" => 1.75,
                "3-" or "-3" => 2.75,
                "4-" or "-4" => 3.75,
                "5-" or "-5" => 4.75,
                "6-" or "-6" => 5.75,
                "1" or "2" or "3" or "4" or "5" or "6" => double.Parse(plusminusgrade),
                _ => throw new ArgumentException("Grade is out of the range")
            };

            return grade;
        }


    }
}
