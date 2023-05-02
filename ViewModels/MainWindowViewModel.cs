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
        }
        #endregion

        #region Commands
        public Command RefreshData { get; }
        #endregion

        #region Command Handlers
        private async void RefreshDataCommandHandler()
        {
            var cp = new CurrencyProcessor(TimeSpan.FromMilliseconds(3000));
            CurrenciesList = await cp.StartPeriodicLoadCurrencies();
            Currencies = new ObservableCollection<Currency>(CurrenciesList);
        }
        #endregion
    }
}
