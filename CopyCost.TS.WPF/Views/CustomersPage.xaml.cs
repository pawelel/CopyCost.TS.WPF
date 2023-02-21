using System.Windows.Controls;
using CopyCost.TS.WPF.ViewModels;

namespace CopyCost.TS.WPF.Views;

public partial class CustomersPage : Page
{
    public CustomersPage(CustomersViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}