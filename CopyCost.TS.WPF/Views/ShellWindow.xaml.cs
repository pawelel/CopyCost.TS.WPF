using System.Windows.Controls;

using CopyCost.TS.WPF.Contracts.Views;
using CopyCost.TS.WPF.ViewModels;

using MahApps.Metro.Controls;

namespace CopyCost.TS.WPF.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();
}
