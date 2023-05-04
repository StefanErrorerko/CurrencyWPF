using CurrencyWPF.Models;
using CurrencyWPF.Utilities;
using System;
using System.Collections.Generic;
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

        public Currency CurrentCurrency
        {
            get => _currentCurrency;
            set
            {
                _currentCurrency = value;
                OnPropertyChanged();
            }
        }

        private CurrencyPageVM()
        {
        }
        public CurrencyPageVM(Currency currency) : this()
        {
            CurrentCurrency = currency;
        }
    }
}
