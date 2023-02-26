using System;
using WyzwanieApp;
using Xunit;

namespace Wyzwanie.Tests
{

    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var emp = new Employee("Adam");

            emp.AddGrade(10);
            emp.AddGrade(54);
            emp.AddGrade(92);

            //act
            var result = emp.GetStatistics();

            //assert
            Assert.Equal(52, result.Average);
            Assert.Equal(92, result.High);
            Assert.Equal(10, result.Low);
        }
    }
}