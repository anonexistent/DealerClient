using DealerClient.View;
using System.Windows;

namespace DealerClient;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        mainFrmae.Navigate(new HomePage());
    }
}
