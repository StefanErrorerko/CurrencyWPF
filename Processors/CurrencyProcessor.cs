using CurrencyWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.Processors
{
    public static class CurrencyProcessor
    {
        public static async Task<List<Currency>> LoadCurrencies()
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
