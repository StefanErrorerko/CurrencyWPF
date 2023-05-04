using CurrencyWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyWPF.Processors
{
    public static class CurrencyProcessor
    {
        private static Task<List<Currency>>? _periodicTask;
        private readonly static PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(3000));
        private readonly static CancellationTokenSource _cts = new();
        private readonly static String _apiUrl = "http://api.coincap.io/v2/";


        public static async Task<List<Currency>> StartPeriodicLoadCurrencies()
        {
            _periodicTask = RunAsync();
            return await _periodicTask;
        }

        private static async Task<List<Currency>> RunAsync()
        {
            try
            {
                while (await _timer.WaitForNextTickAsync(_cts.Token))
                {
                    return await GetAssets();
                }
                throw new NotImplementedException();
            }
            catch (OperationCanceledException) 
            {
                throw new NotImplementedException();
            }
        }

        public static async Task StopAsync()
        {
            if (_periodicTask is null)
            {
                return;
            }

            _cts.Cancel();
            await _periodicTask;
            _cts.Dispose();
        }

        public static async Task<List<Currency>> GetAssets()
        {
            var url = _apiUrl + "assets";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<Currency>>();
                    var currencies = json.Data.ToList();
                    return currencies;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Currency> GetAssetsById(String id)
        {
            var url = _apiUrl + $"assets/{id}/";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonData<Currency>>();
                    return json.Data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<CurrencyInfo>> GetAssetsByIdHistory(String id, String interval)
        {
            var url = _apiUrl + $"assets/{id}/history?interval={interval}";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<CurrencyInfo>>();
                    var currencyInfo = json.Data.ToList();
                    return currencyInfo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Market>> GetAssetsByIdMarkets(String id)
        {
            var url = _apiUrl + $"assets/{id}/markets";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<Market>>();
                    var markets = json.Data.ToList();
                    return markets;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Rate>> GetRates()
        {
            var url = _apiUrl + $"rates";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<Rate>>();
                    var rates = json.Data.ToList();
                    return rates;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Rate> GetRatesById(String id)
        {
            var url = _apiUrl + $"rates/{id}";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var rate = await response.Content.ReadAsAsync<Rate>();
                    return rate;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Exchange> GetExchangesById(String id)
        {
            var url = _apiUrl + $"exchanges/{id}";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var exchange = await response.Content.ReadAsAsync<Exchange>();
                    return exchange;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Exchange>> GetExchanges()
        {
            var url = _apiUrl + $"exchanges";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<Exchange>>();
                    var exchanges = json.Data.ToList();
                    return exchanges;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Market>> GetMarkets()
        {
            var url = _apiUrl + $"markets";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JsonArrayData<Market>>();
                    var markets = json.Data.ToList();
                    return markets;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
