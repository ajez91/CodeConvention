using CodeConvention.Solid.IntSegreg.Interfaces;
using System;

namespace CodeConvention.Solid.IntSegreg.Models
{
    // 3) As a result, our classes can implement only the methods they need:
    //public class MultiFunctionalCar : IVehicle

    // 4) Once we have our higher level interface, we can implement it in different ways. 
    //The first one is to implement the required methods:
    //public class MultiFunctionalCar : IAirplane, ICar
    public class MultiFunctionalCar : IMultiFunctionalVehicle

    {
        // 5) if we already have implemented the Car class and the Airplane class, 
        //we can use them inside our class by using the decorator pattern:

        private readonly ICar _car;
        private readonly IAirplane _airplane;
        public MultiFunctionalCar(ICar car, IAirplane airplane)
        {
            _car = car;
            _airplane = airplane;
        }
        public string Drive()
        {
            return _car.Drive();
        }
        public string Fly()
        {
            return _airplane.Fly();
        }
    }
}
