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
        public CreateDealerPage()
        {
            InitializeComponent();

            var temp = new MainViewModel().DealerTypes;
            cbType.ItemsSource = temp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage.RootFrame.GoBack();
        }

        private void btnCreateDealer_Click(object sender, RoutedEventArgs e)
        {
            var createBode = new CreateDealerBody()
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                TypeId = ((DealerType)cbType.SelectedItem).Id.ToString(),
            };
            var m = new MainViewModel();
            var isOk = m.CreateDealerAsync(createBode).Result;
            MessageBox.Show(isOk.ToString());
        }
    }
}
