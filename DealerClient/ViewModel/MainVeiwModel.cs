using DealerClient.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DealerClient.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    private IMainWindowsCodeBehind _mainCodeBehind;

    private readonly Stack<Page> _navigationStack = new Stack<Page>();
    public ICommand GoToDealerPageCommand { get; }
    public ICommand GoToDealerTypePageCommand { get; }
    public ICommand GoBackCommand { get; }

    public MainViewModel(IMainWindowsCodeBehind codeBehind)
    {
        GoToDealerPageCommand = new RelayCommand(GoToDealerPage);
        GoToDealerTypePageCommand = new RelayCommand(GoToDealerTypePage);
        GoBackCommand = new RelayCommand(GoBack, CanGoBack);

        if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

        _mainCodeBehind = codeBehind;
    }

    private RelayCommand _showMessageCommand;
    public RelayCommand ShowMessageCommand
    {
        get
        {
            return _showMessageCommand = _showMessageCommand ??
                new RelayCommand(OnShowMessage, CanShowMessage);
        }
    }
    private bool CanShowMessage(object parameter)
    {
        return true;
    }
    private void OnShowMessage(object parameter)
    {
        _mainCodeBehind.ShowMessage("Привет от MainUC");
    }

    private void GoToDealerPage(object parameter)
    {
        // Сохраняем текущую страницу перед переходом
        if (App.Current.MainWindow.Content is Page currentPage)
        {
            _navigationStack.Push(currentPage);
            // Уведомляем о изменении доступности команды "Назад"
            ((RelayCommand)GoBackCommand).RaiseCanExecuteChanged();
        }
        App.Current.MainWindow.Content = new DealerPage();
    }

    private void GoToDealerTypePage(object parameter)
    {
        // Сохраняем текущую страницу перед переходом
        if (App.Current.MainWindow.Content is Page currentPage)
        {
            _navigationStack.Push(currentPage);
            // Уведомляем о изменении доступности команды "Назад"
            ((RelayCommand)GoBackCommand).RaiseCanExecuteChanged();
        }
        App.Current.MainWindow.Content = new DealerTypePage();
    }

    private void GoBack(object parameter)
    {
        if (_navigationStack.Count > 0)
        {
            var previousPage = _navigationStack.Pop(); // Получаем предыдущую страницу
            App.Current.MainWindow.Content = previousPage; // Переход на предыдущую страницу
            // Уведомляем о изменении доступности команды "Назад"
            ((RelayCommand)GoBackCommand).RaiseCanExecuteChanged();
        }
    }

    public bool CanGoBack(object parameter)
    {
        return _navigationStack.Count > 0; // Проверяем, есть ли страницы для возврата
    }
}