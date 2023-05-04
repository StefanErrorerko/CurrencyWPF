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
        
        public ObservableCollection<Currency> CurrenciesHistory = new ObservableCollection<Currency>();
        public Currency CurrentCurrency
        {
            get => _currentCurrency;
            set
            {
                _currentCurrency = value;
                OnPropertyChanged();
            }
        }
        public CurrencyPageVM(Currency currency)
        {
            var id = currency.Id;
            suka = new RelayCommand(() => RequestDataById(id));
            //RequestDataById(id);
            //RequestHistoryById(id);
        }

        public RelayCommand suka { get; }

        private async void RequestDataById(String id) => CurrentCurrency = await CurrencyProcessor.GetAssetsById(id);
        private async void RequestHistoryById(String id) 
            => CurrenciesHistory = new (await CurrencyProcessor.GetAssetsByIdHistory(id));
    }
}
