using CommunityToolkit.Mvvm.ComponentModel;

namespace CopyCost.TS.WPF.Core.Models;

public partial class Payment : ObservableObject
{
    [ObservableProperty] private int _amount;

    [ObservableProperty] private Category _category;

    [ObservableProperty] private int _categoryId;

    [ObservableProperty] private Customer _customer;

    [ObservableProperty] private int _customerId;

    [ObservableProperty] private DateTime _date;

    [ObservableProperty] private int _paymentId;

    [ObservableProperty] private decimal _per1000;

    [ObservableProperty] private decimal _price;
}