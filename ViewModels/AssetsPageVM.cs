using CurrencyWPF.Commands;
using CurrencyWPF.Models;
using CurrencyWPF.Processors;
using CurrencyWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CurrencyWPF.ViewModels
{
    public class AssetsPageVM : ViewModelBase
    {
        #region Constants
        public const int topNum = 25;
        #endregion

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
        }
        private async void StopUpdateCommandHandler()
        {
            await CurrencyProcessor.StopAsync();
        }


        #endregion

        #region Methods
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
