using CodeConvention.Solid.OpenClos.Models;
using CodeConvention.Solid.OpenClos.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeConvention.Solid.OpenClos.Tests
{
    public class OpenClosedTests
    {
        [Test]
        public void DevCalculations()
        {
            //Arrange
            var devCalculations = new List<BaseSalaryCalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };

            //Act 
            var calculator = new SalaryCalculator(devCalculations);
            double manualCalculator = ((30.5 * 160) + (30.5 * 180))* 1.2 + (20 * 150);

            //Assert
            Assert.That(calculator.CalculateTotalSalaries(), Is.EqualTo(manualCalculator));
        }
    }
}
