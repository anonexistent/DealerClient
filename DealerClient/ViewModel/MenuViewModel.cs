using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerClient.ViewModel;

public class MenuViewModel
{
    public MenuViewModel()
    {

    }

    public IMainWindowsCodeBehind CodeBehind { get; set; }


    private RelayCommand _LoadFirstUCCommand;
    public RelayCommand LoadFirstUCCommand
    {
        get
        {
            return _LoadFirstUCCommand = _LoadFirstUCCommand ??
              new RelayCommand(OnLoadFirstUC, CanLoadFirstUC);
        }
    }
    private bool CanLoadFirstUC(object parameter)
    {
        return true;
    }
    private void OnLoadFirstUC(object parameter)
    {
        CodeBehind.LoadView(ViewType.First);
    }


    private RelayCommand _LoadSecondUCCommand;
    public RelayCommand LoadSecondUCCommand
    {
        get
        {
            return _LoadSecondUCCommand = _LoadSecondUCCommand ??
              new RelayCommand(OnLoadSecondUC, CanLoadSecondUC);
        }
    }
    private bool CanLoadSecondUC(object parameter)
    {
        return true;
    }
    private void OnLoadSecondUC(object parameter)
    {
        CodeBehind.LoadView(ViewType.Second);
    }


    private RelayCommand _LoadMainUCCommand;
    public RelayCommand LoadMainUCCommand
    {
        get
        {
            return _LoadMainUCCommand = _LoadMainUCCommand ??
              new RelayCommand(OnLoadMainUC, CanLoadMainUC);
        }
    }
    private bool CanLoadMainUC(object parameter)
    {
        return true;
    }
    private void OnLoadMainUC(object parameter)
    {
        CodeBehind.LoadView(ViewType.Main);
    }

}
