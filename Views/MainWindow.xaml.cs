﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json.Serialization;
using CurrencyWPF.Processors;

namespace CurrencyWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var currencies = await CurrencyProcessor.LoadCurrencies();
            dgCurrencies.DataContext = currencies;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBoxHiddenLabel.Visibility = Visibility.Visible;
            }
            else
            {
                SearchTextBoxHiddenLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
