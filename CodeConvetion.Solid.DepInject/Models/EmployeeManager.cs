using CodeConvetion.Solid.DepInject.Enums;
using CodeConvetion.Solid.DepInject.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CodeConvetion.Solid.DepInject.Objects
{
    public class EmployeeManager : IEmployeeSearchable // 1) Add interface to use Dependency Injection
    {
        private readonly List<Employee> _employees;

        public EmployeeManager()
        {
            _employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
        // 2) Comment out method below and implement new method to apply interface. go to EmployeeStatistics.cs
        //public List<Employee> Employees => _employees;

        public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
        => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    }
}
