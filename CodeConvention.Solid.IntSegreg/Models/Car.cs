using CodeConvention.Solid.IntSegreg.Interfaces;
using System;

namespace CodeConvention.Solid.IntSegreg.Models
{
    // 3) As a result, our classes can implement only the methods they need:
    //public class Car : IVehicle
    public class Car : ICar
    {
        public void Drive()
        {
            //actions to drive a car
            Console.WriteLine("Driving a car");
        }

        // 1) That is a bad idea because we should be writing our code to do something and not just to throw exceptions.
        //public void Fly()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
