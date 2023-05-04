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
        #region Properties
        Currency _selectedCurrency;
        List<Currency> _currenciesList;
        CurrencyProcessor _cp;
        #endregion

        #region Fields
        public ObservableCollection<Currency> Currencies { get; set; }
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
            ApiHelper.InitializeClient();

            RefreshData = new RelayCommand(() => RefreshDataCommandHandler());
            StopUpdate = new RelayCommand(() => StopUpdateCommandHandler());
        }
        #endregion

        #region Commands
        public RelayCommand RefreshData { get; }
        public RelayCommand StopUpdate { get; }
        #endregion

        #region CommandHandlers
        private async void RefreshDataCommandHandler()
        {
            _cp = new CurrencyProcessor();
            CurrenciesList = await _cp.LoadCurrencies();
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
            await _cp.StopAsync();
        }
        #endregion
    }
}
