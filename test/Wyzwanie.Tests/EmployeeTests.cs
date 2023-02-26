using System;
using WyzwanieApp;
using Xunit;

namespace Wyzwanie.Tests
{

    public class EmployeeTests
    {
        private Employee employee;

        private void Init()
        {
            employee = new Employee("Superman");
        }

        [Fact]
        public void AddGrade_WhenCalled_ShouldChangeAvarage()
        {
            Init();

            employee.AddGrade("5");
            employee.AddGrade("4");

            Assert.Equal(4.5, employee.GetStatistics().Average);

        }

        [Fact]
        public void AddGrade_WhenCalled_ShouldAddGradesToLlist()
        {

            Employee employee2 = new Employee("Test");

            employee2.AddGrade("5");
            employee2.AddGrade("4");

            Assert.Equal(2, employee2.GetStatistics().Count);

        }
    }
}