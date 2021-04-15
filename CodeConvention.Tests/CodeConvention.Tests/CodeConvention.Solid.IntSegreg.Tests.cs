using CodeConvention.Solid.IntSegreg.Models;
using NUnit.Framework;

namespace CodeConvetion.Solid.IntSegreg.Tests
{
    public class IntegrationSegregationTests
    {
        [Test]
        public void MultifuntionalVehicle()
        {
            //Arrange
            var car = new Car();
            var airplane = new Airplane();

            //Act
            var multiVehicle = new MultiFunctionalCar(car, airplane);

            //Assert
            Assert.That(multiVehicle.Drive, Is.EqualTo("Driving a car"));
            Assert.That(multiVehicle.Fly, Is.EqualTo("Flying a plane"));
        }
    }
}
