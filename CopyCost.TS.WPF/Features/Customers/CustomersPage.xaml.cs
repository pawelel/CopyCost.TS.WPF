using System.Windows.Controls;
using CopyCost.TS.WPF.Features.Customers;

namespace CopyCost.TS.WPF.Views;

public partial class CustomersPage : Page
{
    public CustomersPage(CustomersViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}