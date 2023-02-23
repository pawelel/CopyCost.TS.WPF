using System.Windows.Controls;
using CopyCost.TS.WPF.Features.Categories;

namespace CopyCost.TS.WPF.Views;

public partial class CategoriesPage : Page
{
    public CategoriesPage(CategoriesViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}