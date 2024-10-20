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
using System.Windows.Shapes;

namespace DealerClient.View
{
    /// <summary>
    /// Логика взаимодействия для CreateDealerTypePage.xaml
    /// </summary>
    public partial class CreateDealerTypePage : Page
    {
        public CreateDealerTypePage()
        {
            InitializeComponent();
        }

        private async void btnCreateDealer_Click(object sender, RoutedEventArgs e)
        {
            var createBode = new CreateDealerTypeBody()
            {
                Name = tbName.Text,
            };
            var m = new MainViewModel();
            var isOk = await m.CreateDealerTypeAsync(createBode);
            MessageBox.Show(isOk.ToString());

            tbName.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new HomePage());
        }
    }
}
