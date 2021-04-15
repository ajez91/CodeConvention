using CodeConvetion.Solid.DepInject.Enums;
using CodeConvetion.Solid.DepInject.Objects;
using NUnit.Framework;

namespace CodeConvetion.Solid.DepInject.Tests
{
    public class DependencyInjectionTests
    {
        [Test]
        public void CountFemaleManagers()
        {
            //Arrange
            var empManager = new EmployeeManager();
            empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });

            //Act
            var stats = new EmployeeStatistics(empManager);

            //Assert
            Assert.That(stats.CountFemaleManagers(), Is.EqualTo(1));
            Assert.That(stats.CountMaleAdmins(), Is.EqualTo(1));
        }
    }
}
