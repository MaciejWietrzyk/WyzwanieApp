using System;
using System.Collections.Generic;
using System.IO;

namespace WyzwanieApp
{
    public class SavedEmployee : EmployeeBase
    {
        private List<double> grades = new List<double>();

        private const string filename = "Grades.txt";

        private const string auditfilename = "audit.txt";
        public SavedEmployee(string name) : base(name)
        {
            LowerGrade += OnLowGrade;
        }

        public override event Employee.LowerGradeDelegate LowerGrade;
        public void SaveGrade(string plusminusgrade)
        {
            double grade = 0.0;
            try
            {
                grade = double.Parse(plusminusgrade);
                {

                    AddPlusMinusGrade(plusminusgrade);

                    using (var writer = File.AppendText($"{Name} {auditfilename}"))
                    {
                        writer.WriteLine($"Grade: {plusminusgrade} Date: {DateTime.Now}");
                    }

                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }

        }
        void OnLowGrade(object sender, EventArgs args)

        {
            Console.WriteLine("Oh, no! We should inform boss about this fact");
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            if (!File.Exists($"{Name} {filename}"))
            {
                return null;
            }
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
            var grade = plusminusgrade switch
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

            using (var writer = File.AppendText($"{Name} {filename}"))
            {
                writer.WriteLine(grade);
            }

            if (LowerGrade != null && grade < 3)
            {
                LowerGrade(this, new EventArgs());
            }
        }
    }
}