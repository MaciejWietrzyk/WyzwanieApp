using System;
using System.Collections.Generic;
using System.IO;

namespace WyzwanieApp
{
    public class SavedEmployee
    {
        private List<double> grades = new List<double>();

        private const string filename = "Grades.txt";

        private const string auditfilename = "audit.txt";

        public SavedEmployee()
        {

        }

        public void SaveGrade(string name, double grade)
        {

            using (var writer = File.AppendText($"{name} {auditfilename}"))
            {
                writer.WriteLine($"Grade: {grade} Date: {DateTime.Now}");
            }

            using (var writer = File.AppendText($"{name} {filename}"))
            {
                writer.WriteLine(grade);
            }
        }
    }
}