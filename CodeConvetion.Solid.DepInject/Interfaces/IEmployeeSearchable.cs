using CodeConvetion.Solid.DepInject.Enums;
using CodeConvetion.Solid.DepInject.Objects;
using System.Collections.Generic;

namespace CodeConvetion.Solid.DepInject.Interfaces
{
    public interface IEmployeeSearchable
    {
        IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
    }
}
