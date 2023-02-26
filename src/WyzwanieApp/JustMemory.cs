using System;
using System.Collections.Generic;

namespace WyzwanieApp
{
    public class JustMemory : EmployeeBase
    {
        private List<double> grades;

        public void SaveGrade(string plusminusgrade)
        {
            AddPlusMinusGrade(plusminusgrade);
        }
        public JustMemory(string name) : base(name)
        {
            grades = new List<double>();
            LowerGrade += JustMemory_LowerGrade;
        }
        private void JustMemory_LowerGrade(object sender, EventArgs args)
        {
            Console.WriteLine("Oh, no! We should inform boss about this fact");
        }

        public override event Employee.LowerGradeDelegate LowerGrade;
        public override void AddPlusMinusGrade(string plusminusgrade)
        {
            try
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
                grades.Add(grade);

                if (LowerGrade != null && grade < 3)
                {
                    LowerGrade(this, new EventArgs());
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
        public override Statistics GetStatistics()
        {
            {
                Statistics result = new Statistics();

                foreach (var grade in grades)
                {
                    result.Add(grade);
                }

                Console.WriteLine($"The average is: {result.Average:N2}");
                Console.WriteLine($"The the highest number is: {result.High:N2}");
                Console.WriteLine($"The the lowest number is: {result.Low:N2}");

                return result;
            }
        }
    }
}