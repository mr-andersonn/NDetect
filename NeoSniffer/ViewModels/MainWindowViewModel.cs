using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using NetSniffer.Models;

namespace NetSniffer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public string _description { get; set;  }= "";

    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
    }
    
    public ICommand SetDescriptionCommandArp { get; }
    public ICommand SetDescriptionCommandNmap { get; }
    
    
    public MainWindowViewModel()
    {
        SetDescriptionCommandArp = new MyCommand(() => SetDescriptionArp());
        SetDescriptionCommandNmap = new MyCommand(() => SetDescriptionNmap());
    }
    
    private void SetDescriptionArp()
    {
        Description = "Current: ArpScan";
    }
    
    private void SetDescriptionNmap()
    {
        Description = "Current: NmapScan";
    }
    
}

public class MyCommand(Action a) : ICommand
{
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        a();
    }
    
    public event EventHandler? CanExecuteChanged;
}
