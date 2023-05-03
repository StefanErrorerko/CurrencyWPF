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
    /// Interaction logic for CurrencyPage.xaml
    /// </summary>
    public partial class CurrencyPage : UserControl
    {
        public CurrencyPage()
        {
            InitializeComponent();
            DataContext = new CurrencyPageVM();
        }

        private void ButtonBackToMain_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
