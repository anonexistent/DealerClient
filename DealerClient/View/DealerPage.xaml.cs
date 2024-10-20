using DealerAPI.Contracts.Input;
using DealerAPI.Model;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = new MainViewModel().Dealers;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var selectedType = ((Dealer)dgMain.SelectedItem);

            if(selectedType is null)
            {
                MessageBox.Show("Необходимо выбрать объект из списка");
                throw new NullReferenceException("Необходимо выбрать объект из списка");
            }

            var m = new MainViewModel();
            var result = await m.RemoveDealerAsync(new DealerIdQuery() { Id = selectedType.Id.ToString() });

            MessageBox.Show(result.ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var selectedDealer = ((Dealer)dgMain.SelectedItem);

            if (selectedDealer is null)
            {
                MessageBox.Show("Необходимо выбрать объект из списка");
                throw new NullReferenceException("Необходимо выбрать объект из списка");
            }
            HomePage.RootFrame.Navigate(new CreateDealerPage(selectedDealer));
        }
    }
}
