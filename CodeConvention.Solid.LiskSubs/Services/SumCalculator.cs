using System.Linq;

namespace CodeConvention.Solid.LiskSubs.Services
{
    // 3) Then we have to change our other classes:
    public class SumCalculator : Calculator
    {
        //public SumCalculator(int[] numbers)
        //{
        //    _numbers = numbers;
        //}

        public SumCalculator(int[] numbers)
            : base(numbers)
        {
        }

        // 1) we have to do is to implement small modifications to both of our classes:
        //public int Calculate() => _numbers.Sum();
        //public virtual int Calculate() => _numbers.Sum();
        public override int Calculate() => _numbers.Sum();

    }
}
