using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NetSniffer.Models;

namespace NetSniffer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Description { get; set; } = "";

    public ICommand SetDescriptionCommand { get; }
    
    private void SetDescriptionArp()
    {
        Description = "Current: ArpScan";
    }
    private void SetDescriptionNmap()
    {
        Description = "Current: NmapScan";
    }
    
}

public class myCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }
    
    public event EventHandler? CanExecuteChanged;
}
