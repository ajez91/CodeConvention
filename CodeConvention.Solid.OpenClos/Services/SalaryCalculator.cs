using CodeConvention.Solid.OpenClos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeConvention.Solid.OpenClos.Services
{
    public class SalaryCalculator
    {
        //3) Excellent.Now we can modify the SalaryCalculator class:

        //private readonly IEnumerable<DeveloperReport> _developerReports;

        //public SalaryCalculator(List<DeveloperReport> developerReports)
        //{
        //    _developerReports = developerReports;
        //}

        ////1) So, all of this is working great, but now our boss comes to our office and says 
        ////that we need a different calculation for the senior and junior developers. 
        ////The senior developers should have a bonus of 20% on a salary.
        ////To satisfy this requirement, we are going to modify our CalculateTotalSalaries method like this:

        ////public double CalculateTotalSalaries()
        ////{
        ////    double totalSalaries = 0D;

        ////    foreach (var devReport in _developerReports)
        ////    {
        ////        totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
        ////    }

        ////    return totalSalaries;
        ////}
        //public double CalculateTotalSalaries()
        //{
        //    double totalSalaries = 0D;

        //    foreach (var devReport in _developerReports)
        //    {
        //        if (devReport.Level == "Senior developer")
        //        {
        //            totalSalaries += devReport.HourlyRate * devReport.WorkingHours * 1.2;
        //        }
        //        else
        //        {
        //            totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
        //        }
        //    }

        //    return totalSalaries;
        //}

        private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;
        public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
        {
            _developerCalculation = developerCalculation;
        }
        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;
            foreach (var devCalc in _developerCalculation)
            {
                totalSalaries += devCalc.CalculateSalary();
            }
            return totalSalaries;
        }
    }
}
