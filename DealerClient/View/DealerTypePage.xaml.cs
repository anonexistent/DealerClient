﻿using DealerAPI.Contracts.Input;
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
    /// Логика взаимодействия для DealerTypePage.xaml
    /// </summary>
    public partial class DealerTypePage : Page
    {
        public DealerTypePage()
        {
            InitializeComponent();

            dgMain.ItemsSource = new MainViewModel().DealerTypes;
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
            dgMain.ItemsSource = new MainViewModel().DealerTypes;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HomePage.RootFrame.Navigate(new CreateDealerTypePage());

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var selectedType = ((DealerType)dgMain.SelectedItem);

            if (selectedType is null)
            {
                MessageBox.Show("Необходимо выбрать объект из списка");
                throw new NullReferenceException("Необходимо выбрать объект из списка");
            }

            var m = new MainViewModel();
            var result = await m.RemoveDealerTypeAsync(new DealerTypeIdQuery() { DealerTypeId = selectedType.Id.ToString() });

            MessageBox.Show(result.ToString());

        }
    }
}
