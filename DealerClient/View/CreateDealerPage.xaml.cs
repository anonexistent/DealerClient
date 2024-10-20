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
    /// Логика взаимодействия для CreateDealerPage.xaml
    /// </summary>
    public partial class CreateDealerPage : Page
    {
        Dealer current;

        public CreateDealerPage()
        {
            InitializeComponent();

            var temp = new MainViewModel().DealerTypes;
            cbType.ItemsSource = temp;

            btnUpdateDealer.Visibility = Visibility.Collapsed;
            btnCreateDealer.Visibility = Visibility.Visible;
        }

        public CreateDealerPage(Dealer currentItem)
        {
            InitializeComponent();

            current = currentItem;
            var temp = new MainViewModel().DealerTypes;
            cbType.ItemsSource = temp;

            tbName.Text = currentItem.Name;
            tbDescription.Text = currentItem.Description;
            cbType.SelectedItem = currentItem.DealerType;


            btnUpdateDealer.Visibility = Visibility.Visible;
            btnCreateDealer.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }

        private async void btnCreateDealer_Click(object sender, RoutedEventArgs e)
        {
            var createBode = new CreateDealerBody()
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                TypeId = ((DealerType)cbType.SelectedItem).Id.ToString(),
            }; 
            var m = new MainViewModel();
            var isOk = await m.CreateDealerAsync(createBode);
            MessageBox.Show(isOk.ToString());

            tbName.Text = "";
            tbDescription.Text = "";
            cbType.SelectedItem = null;
        }

        private async void btnUpdateDealer_Click(object sender, RoutedEventArgs e)
        {
            var updateBody = new CreateDealerBody()
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                TypeId = ((DealerType)cbType.SelectedItem).Id.ToString(),
            };
            var m = new MainViewModel();
            var isOk = await m.ChangeDealerAsync(current.Id.ToString(), updateBody);
            MessageBox.Show(isOk.ToString());

            MainWindow.MainFrame.GoBack();
        }
    }
}
