﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CurrencyWPF.Views
{
    /// <summary>
    /// Interaction logic for AssetsPage.xaml
    /// </summary>
    public partial class AssetsPage : UserControl
    {
        public AssetsPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.AssetsPageVM();
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

        private void DataGridCell_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var currencyPage = new CurrencyPage();
            this.Content = currencyPage;
        }
    }
}
