using System;
using System.Collections.Generic;
using System.Text;

namespace CodeConvention.Solid.LiskSubs.Services
{
    //2) Still, the behavior of our derived class has changed and it can’t replace the base class. 
    //So we need to upgrade this solution by introducing the Calculator abstract class:
    public abstract class Calculator
    {
        protected readonly int[] _numbers;

        public Calculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public abstract int Calculate();
    }
}
