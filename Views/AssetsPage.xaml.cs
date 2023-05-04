using CurrencyWPF.ViewModels;
using System;
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
        }

        // Placeholder above the SearchTextBox area
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

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cvm = new CurrencyPageVM((DataContext as AssetsPageVM).SelectedCurrency);
            var cv = new CurrencyPage();
            cv.DataContext = cvm;
            Content = cv;
        }
    }
}
