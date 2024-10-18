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

namespace DealerClient.View;


public partial class HomePage : Page
{
    public static Frame RootFrame { get; set; }

    public HomePage()
    {
        InitializeComponent();

        RootFrame = homeFrame;
        homeFrame.Navigate(new DealerTypePage());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        homeFrame.Navigate(new DealerPage());
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        homeFrame.Navigate(new DealerTypePage());
    }
}
