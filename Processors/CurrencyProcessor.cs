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
    public class CurrencyProcessor
    {
        private Task<List<Currency>>? _periodicTask;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cts = new();

        public CurrencyProcessor(TimeSpan interval)
        {
            _timer = new PeriodicTimer(interval);
        }
        public CurrencyProcessor()
        {
            _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(10000));
        }

        public async Task<List<Currency>> StartPeriodicLoadCurrencies()
        {
            _periodicTask = RunAsync();
            return await _periodicTask;
        }

        private async Task<List<Currency>> RunAsync()
        {
            try
            {
                while (await _timer.WaitForNextTickAsync(_cts.Token))
                {
                    return await LoadCurrencies();
                }
                throw new NotImplementedException();
            }
            catch (OperationCanceledException) 
            {
                throw new NotImplementedException();
            }
        }

        public async Task StopAsync()
        {
            if (_periodicTask is null)
            {
                return;
            }

            _cts.Cancel();
            await _periodicTask;
            _cts.Dispose();
        }

        public async Task<List<Currency>> LoadCurrencies()
        {
            string url = "http://api.coincap.io/v2/assets";
            using (var response = await ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<CurrencyJsonData>();
                    var currencies = json.Data.ToList();
                    return currencies;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
