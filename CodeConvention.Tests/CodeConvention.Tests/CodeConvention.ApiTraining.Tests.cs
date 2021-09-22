using CodeConvention.ApiTraining.Services;
using CodeConvention.CustomExceptions;
using NUnit.Framework;
using System;
using System.IO;

namespace CodeConvention.ApiTraining.Tests
{
    public class ApiTrainingTests
    {

        private CurrencyApi _currencyApi;

        [Test]
        public void CurrenciesEndpointStatus()
        {
            //Arrange
            _currencyApi = new CurrencyApi("currencies");

            //Assert
            Assert.That(_currencyApi.GetCurrencies().StatusDescription, Is.EqualTo("OK"));
        }

        [Test]
        public void PolishCurrencyVisibility()
        {
            //Arrange
            _currencyApi = new CurrencyApi("currencies");

            //Assert
            Assert.That(_currencyApi.GetCurrencies().Content, Contains.Substring("PLN"));
        }
        
        [Test]
        public void GetRatesBase()
        {
            //Arrange
            _currencyApi = new CurrencyApi("rates");

            //Assert
            Assert.That(_currencyApi.GetRates().Base, Is.EqualTo("USD"));
        }

        [Test]
        public void RefOut()
        {
            var testRef = "REF";

            ZrobCosZArgumentemRef(ref testRef);

            System.Console.WriteLine(testRef);

            string testOut;

            ZrobCosZArgumentemOut(out testOut);

            System.Console.WriteLine(testOut);
        }

        void ZrobCosZArgumentemRef(ref string argRef)
        {
            argRef += "REF";
        }

        void ZrobCosZArgumentemOut(out string argOut)
        {
            argOut = string.Empty; ;
            argOut += "OUT";
        }

        [Test]
        public void SwitchCaseString()
        {

            Console.WriteLine(Path.GetFullPath("."));
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.Id);

            Assert.AreEqual(ReturnSwitchCaseString(0), "camelCaseString");
        }
        string ReturnSwitchCaseString(int number)
        {
            return number switch
            {
                1 => "camelCaseString",
                2 => "UPPERCASESTRING",
                3 => "lowercasestring",
                _ => throw new ArgumentOutOfRangeException()
            };
        }


        [Test]
        public void ReadingFile()
        {

            using (StreamReader stream = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "anteny.txt")))
            {
                while (!stream.EndOfStream)
                {
                    Console.WriteLine(stream.ReadLine());
                }
                stream.Close();
            }
        }

        [Test]
        public void CustomExceptionTest()
        {

            var divider = 0;

            try
            {
                int result = 100 / divider;

            }
            catch(Exception ex)
            {
                throw new MyOwnException(ex.Message, ex.GetBaseException());
            }
        } 
    }
}
