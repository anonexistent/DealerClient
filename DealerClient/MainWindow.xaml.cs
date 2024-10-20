using DealerClient.View;
using System.Windows;
using System.Windows.Controls;

namespace DealerClient;

public partial class MainWindow : Window
{
    public static Frame MainFrame;

    public MainWindow()
    {
        InitializeComponent();

        MainFrame = mainFrmae;
        MainFrame.Navigate(new HomePage());
    }
}
