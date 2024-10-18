using DealerClient.ViewModel;
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

namespace DealerClient.View
{
    /// <summary>
    /// Логика взаимодействия для DealerPage.xaml
    /// </summary>
    public partial class DealerPage : Page
    {
        public DealerPage()
        {
            InitializeComponent();

            dgMain.ItemsSource = new MainViewModel().Dealers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HomePage.RootFrame.GoBack();

            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HomePage.RootFrame.Navigate(new CreateDealerPage());
        }
    }
}
