using CodeConvention.Solid.IntSegreg.Interfaces;
using System;

namespace CodeConvention.Solid.IntSegreg.Models
{
    // 3) As a result, our classes can implement only the methods they need:
    //public class Airplane : IVehicle
    public class Airplane : IAirplane
    {
        // 1) That is a bad idea because we should be writing our code to do something and not just to throw exceptions.
        //public void Drive()
        //{
        //    throw new NotImplementedException();
        //}

        public string Fly() => "Flying a plane";

    }
}
