using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CopyCost.TS.WPF.Contracts.Services;
using CopyCost.TS.WPF.ViewModels;
using CopyCost.TS.WPF.Views;

namespace CopyCost.TS.WPF.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();
    private readonly IServiceProvider _serviceProvider;

    public PageService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        Configure<PaymentsViewModel, PaymentsPage>();
        Configure<CustomersViewModel, CustomersPage>();
        Configure<CategoriesViewModel, CategoriesPage>();
        Configure<SettingsViewModel, SettingsPage>();
    }

    public Type GetPageType(string key)
    {
        Type pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
        }

        return pageType;
    }

    public Page GetPage(string key)
    {
        var pageType = GetPageType(key);
        return _serviceProvider.GetService(pageType) as Page;
    }

    private void Configure<TVm, TV>()
        where TVm : ObservableObject
        where TV : Page
    {
        lock (_pages)
        {
            var key = typeof(TVm).FullName;
            if (_pages.ContainsKey(key))
                throw new ArgumentException($"The key {key} is already configured in PageService");

            var type = typeof(TV);
            if (_pages.Any(p => p.Value == type))
                throw new ArgumentException(
                    $"This type is already configured with key {_pages.First(p => p.Value == type).Key}");

            _pages.Add(key, type);
        }
    }
}