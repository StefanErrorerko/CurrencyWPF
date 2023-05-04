using CurrencyWPF.Commands;
using CurrencyWPF.Models;
using CurrencyWPF.Processors;
using CurrencyWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyWPF.ViewModels
{
    public class AssetsPageVM : ViewModelBase
    {
        public const int topNum = 25;

        #region Properties
        Currency _selectedCurrency;
        List<Currency> _currenciesList;
        String _searchValue;
        #endregion

        #region Fields
        public ObservableCollection<Currency> Currencies { get; set; }
        public String SearchValue
        {
            get => _searchValue;
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));
                SearchByValue();
            }
        }
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
            }
        }
        public List<Currency> CurrenciesList
        {
            get => _currenciesList;
            set
            {
                _currenciesList = value;
                OnPropertyChanged(nameof(CurrenciesList));
            }
        }
        #endregion

        #region Constructors
        public AssetsPageVM()
        {
            Currencies = new ObservableCollection<Currency>();
            RequestData();
            StopUpdate = new RelayCommand(() => StopUpdateCommandHandler());
        }
        #endregion

        #region Commands
        public RelayCommand StopUpdate { get; }
        #endregion

        #region CommandHandlers
        private async void RequestData()
        {
            CurrenciesList = (await CurrencyProcessor.GetAssets())
                                .Take(topNum)
                                .ToList();
            Currencies = new ObservableCollection<Currency>(CurrenciesList);

            //async prompt 
            //if(_cp is null)
            //{
            //    _cp = new CurrencyProcessor(TimeSpan.FromMilliseconds(3000));
            //    CurrenciesList = await _cp.StartPeriodicLoadCurrencies();
            //    Currencies = new ObservableCollection<Currency>(CurrenciesList);
            //}

        }
        private async void StopUpdateCommandHandler()
        {
            
            //await _cp.StopAsync();
        }

        private void SearchByValue()
        {
            if (String.IsNullOrEmpty(SearchValue))
            {
                CurrenciesList = Currencies.ToList();
            }
            else
            {
                CurrenciesList = Currencies
                    .Where(c => c.Id
                        .Contains(SearchValue, StringComparison.OrdinalIgnoreCase) 
                            || c.Name.Contains(SearchValue, StringComparison.OrdinalIgnoreCase)
                            || c.Symbol.Contains(SearchValue, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c)
                    .ToList();
            }
            
        }
        #endregion
    }
}
