using System.Windows.Controls;
using CopyCost.TS.WPF.Features.Settings;

namespace CopyCost.TS.WPF.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}