using CodeConvetion.Solid.DepInject.Enums;
using CodeConvetion.Solid.DepInject.Interfaces;
using System.Linq;

namespace CodeConvetion.Solid.DepInject.Objects
{
    public class EmployeeStatistics
    {
        // 3) Comment out EmployeeManager field. Use prepared interface to implement Dependency Injection
        //private readonly EmployeeManager _empManager;
        private readonly IEmployeeSearchable _emp;

        public EmployeeStatistics(IEmployeeSearchable emp)
        {
            _emp = emp;
        }

        public int CountFemaleManagers() =>
          _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();

        public int CountMaleAdmins() => _emp.GetEmployeesByGenderAndPosition(Gender.Male, Position.Administrator).Count();
    }
}
