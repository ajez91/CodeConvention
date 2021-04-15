using CodeConvention.Solid.OpenClos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeConvention.Solid.OpenClos.Services
{
    // 2) As a continuation, we are going to create two classes which will inherit from the BaseSalaryCalculator class.
    // Because it is obvious that our calculation depends on the developer’s level, 
    //we are going to create our new classes in that manner:
    public class JuniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDevSalaryCalculator(DeveloperReport developerReport)
            : base(developerReport)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
    }
}
