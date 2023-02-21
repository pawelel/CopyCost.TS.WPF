using System.Windows.Controls;
using CopyCost.TS.WPF.ViewModels;

namespace CopyCost.TS.WPF.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}