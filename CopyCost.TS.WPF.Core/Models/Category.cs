using CommunityToolkit.Mvvm.ComponentModel;

namespace CopyCost.TS.WPF.Core.Models;

public partial class Category : ObservableObject
{
    [ObservableProperty]
    private int _categoryId;
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _description;
    [ObservableProperty]
    private ICollection<Payment> _payments;
}
