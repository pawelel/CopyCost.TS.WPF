using System.Windows.Controls;
using CopyCost.TS.WPF.ViewModels;

namespace CopyCost.TS.WPF.Views;

public partial class PaymentsPage : Page
{
    public PaymentsPage(PaymentsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}