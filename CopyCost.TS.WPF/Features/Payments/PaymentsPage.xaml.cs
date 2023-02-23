using System.Windows.Controls;
using CopyCost.TS.WPF.Features.Payments;

namespace CopyCost.TS.WPF.Views;

public partial class PaymentsPage : Page
{
    public PaymentsPage(PaymentsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}