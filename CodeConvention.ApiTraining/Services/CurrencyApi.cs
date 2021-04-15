using CodeConvention.ApiTraining.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CodeConvention.ApiTraining.Services
{
    public class CurrencyApi
    {
        public RestClient _client;
        public RestRequest _request;
        public static string _apiKey = "hZXVyLVM137PrSFVdCTvd3hJ4yCQ5eMNoFwX";

        public CurrencyApi(string endpoint)
        {
            _client = new RestClient("https://currencyapi.net/api/v1");
            _request = new RestRequest($"{endpoint}", Method.GET);
            _request.AddParameter("key", _apiKey);
            _request.AddParameter("output", "JSON");
        }
        public IRestResponse GetCurrencies() => _client.Execute(_request);

        public Rates GetRates()
        {
            IRestResponse response = _client.Execute(_request);

            Rates rates = JsonConvert.DeserializeObject<Rates>(response.Content);

            return rates;
        }
    }
}
