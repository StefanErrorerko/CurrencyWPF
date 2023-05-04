using CurrencyWPF.Commands;
using CurrencyWPF.Models;
using CurrencyWPF.Processors;
using CurrencyWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWPF.ViewModels
{
    public class CurrencyPageVM : ViewModelBase
    {
        Currency _currentCurrency;
        List<CurrencyInfo> _currencyHistoryList;
        List<Currency> _currenciesList;
        String _searchValue;


        public ObservableCollection<CurrencyInfo> CurrenciesHistory = new();
        public Currency CurrentCurrency
        {
            get => _currentCurrency;
            set
            {
                _currentCurrency = value;
                OnPropertyChanged();
            }
        }
        public String SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));
                SearchByValueAsync();
            }
        }
        public List<CurrencyInfo> CurrencyHistoryList
        {
            get => _currencyHistoryList;
            set
            {
                _currencyHistoryList = value;
                OnPropertyChanged();
            }
        }
        public CurrencyPageVM() 
        {
        }
        public CurrencyPageVM(Currency currency)
        {
            RequestDataById(id: currency.Id);
            RequestHistoryById(id: currency.Id);
        }

        private async void RequestDataById(String id) 
            => CurrentCurrency = await CurrencyProcessor.GetAssetsById(id);
        private async void RequestHistoryById(String id)
        {
            CurrencyHistoryList = await CurrencyProcessor.GetAssetsByIdHistory(id, "d1");
            CurrenciesHistory = new(CurrencyHistoryList);
        }

        private async Task SearchByValueAsync()
        {
            if(_currenciesList is null)
            {
                _currenciesList = await CurrencyProcessor.GetAssets();
            }
            if (!String.IsNullOrEmpty(SearchValue))
            {
                var currency = _currenciesList
                    .Where(c => c.Id
                        .Contains(SearchValue, StringComparison.OrdinalIgnoreCase)
                            || c.Name.Contains(SearchValue, StringComparison.OrdinalIgnoreCase)
                            || c.Symbol.Contains(SearchValue, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c)
                    .FirstOrDefault();
                if(currency != null)
                {
                    CurrentCurrency = currency;
                    RequestHistoryById(currency.Id);
                }
            }

        }
    }
}
