using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CurrencyWPF.Models;
using CurrencyWPF.Commands;
using CurrencyWPF.Processors;

namespace CurrencyWPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] String prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

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
        public MainWindowViewModel()
        {
            Currencies = new ObservableCollection<Currency>();
            ApiHelper.InitializeClient();

            RefreshData = new Command(() => RefreshDataCommandHandler());
            StopUpdate = new Command(() => StopUpdateCommandHandler());
        }
        #endregion

        #region Commands
        public Command RefreshData { get; }
        public Command StopUpdate { get; }
        #endregion

        #region Command Handlers
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
