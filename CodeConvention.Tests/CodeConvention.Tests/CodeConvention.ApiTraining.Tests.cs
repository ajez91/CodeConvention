using CodeConvention.ApiTraining.Services;
using NUnit.Framework;

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
    }
}
