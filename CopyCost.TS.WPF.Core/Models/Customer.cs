using CommunityToolkit.Mvvm.ComponentModel;

namespace CopyCost.TS.WPF.Core.Models;

public partial class Customer : ObservableObject
{
    [ObservableProperty] private int _customerId;

    [ObservableProperty] private string _description;

    [ObservableProperty] private string _name;

    // navigation property for payments
    [ObservableProperty] private ICollection<Payment> _payments;
}