using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using NetSniffer.Models;

namespace NetSniffer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public string _description { get; set; } = "";
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
    
    public ICommand SetDescriptionCommand { get; }
    
    public MainWindowViewModel()
    {
        SetDescriptionCommand = new MyCommand((parameter) => SetDescription(parameter));
    }

    private void SetDescription(string? description)
    {
        Description = $"Current: {description}";
    }
    
}

public class MyCommand(Action<string> a) : ICommand
{
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        a(parameter?.ToString() ?? "");
    }
    
    public event EventHandler? CanExecuteChanged;
}
