using CodeConvention.Solid.LiskSubs.Services;
using NUnit.Framework;

namespace CodeConvention.Solid.LiskSubs.Tests
{
    public class LiskovSubstitutionTests
    {
        [Test]
        public void EvenSumCalculator()
        {
            //Arrange
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            //Act
            // 4) Excellent. Now we can start making calls towards these classes:
            //SumCalculator sum = new SumCalculator(numbers);
            //EvenNumbersSumCalculator evenSum = new EvenNumbersSumCalculator(numbers);
            Calculator sum = new SumCalculator(numbers);
            Calculator evenSum = new EvenNumbersSumCalculator(numbers);

            //Assert
            Assert.That(sum.Calculate(), Is.EqualTo(40));
            Assert.That(evenSum.Calculate(), Is.EqualTo(18));
        }
    }
}
