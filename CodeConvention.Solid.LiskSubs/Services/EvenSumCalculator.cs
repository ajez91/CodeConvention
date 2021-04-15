using System.Linq;

namespace CodeConvention.Solid.LiskSubs.Services
{
    // 3) Then we have to change our other classes:
    public class EvenNumbersSumCalculator : Calculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
        }

        // 1) we have to do is to implement small modifications to both of our classes:
        //public new int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();

    }
}
