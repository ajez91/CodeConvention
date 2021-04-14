using System;
using System.Collections.Generic;
using System.Text;

namespace CodeConvention.Solid.IntSegreg.Interfaces
{
    // 4) We can even use a higher level interface 
    //if we want in a situation where a single class implements more than one interface:
    public interface IMultiFunctionalVehicle : ICar, IAirplane
    {
    }
}
