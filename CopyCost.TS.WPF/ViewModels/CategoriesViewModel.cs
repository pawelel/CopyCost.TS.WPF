using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CopyCost.TS.WPF.Contracts.ViewModels;
using CopyCost.TS.WPF.Core.Contracts.Services;
using CopyCost.TS.WPF.Core.Models;

namespace CopyCost.TS.WPF.ViewModels;

public class CategoriesViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;
    private SampleOrder _selected;

    public CategoriesViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public SampleOrder Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public ObservableCollection<SampleOrder> SampleItems { get; } = new();

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();

        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data) SampleItems.Add(item);

        Selected = SampleItems.First();
    }

    public void OnNavigatedFrom()
    {
    }
}