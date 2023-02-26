using System;
using WyzwanieApp;
using Xunit;

namespace Wyzwanie.Tests
{

    public class TypeTests
    {
        [Fact]
        public void GetEmployeeReturnsDifferentObjects()
        {
            var emp1 = GetEmployee("Adam");
            var emp2 = GetEmployee("Tomek");
            var emp3 = emp1;

            Assert.Equal("Adam", emp1.Name);
            Assert.Equal("Tomek", emp2.Name);
            Assert.NotSame(emp1, emp2);
            Assert.Same(emp1, emp3);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
            Assert.True(Employee.Equals(emp3, emp1));
        }

        [Fact]
        public void CanSetNameFromRefferences()
        {
            var emp1 = GetEmployee("Adam");
            this.SetName(emp1, "Maciek");
            Assert.Equal("Maciek", emp1.Name);
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }

        private void SetName(Employee employee, string name)
        {
            employee.Name = name;
        }
    }
}
