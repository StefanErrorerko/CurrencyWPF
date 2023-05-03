﻿using System;
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
using CurrencyWPF.Utilities;
using CurrencyWPF.Views;

namespace CurrencyWPF.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {

        #region Properties
        object _currentView;
        #endregion

        #region Fields
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainWindowVM()
        {
            AssetsOpen = new RelayCommand(() =>  AssetsOpenCommandHandler());
            CurrentView = new AssetsPage();
        }
        #endregion

        #region Commands
        public RelayCommand AssetsOpen { get; }
        #endregion

        #region Command Handlers
        private void AssetsOpenCommandHandler() => CurrentView = new AssetsPage();
        #endregion
    }
}