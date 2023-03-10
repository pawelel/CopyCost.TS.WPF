using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CopyCost.TS.WPF.Contracts.ViewModels;
using CopyCost.TS.WPF.Core.Contracts.Services;
using CopyCost.TS.WPF.Core.Models;

namespace CopyCost.TS.WPF.ViewModels;

public class PaymentsViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public PaymentsViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public ObservableCollection<SampleOrder> Source { get; } = new();

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // Replace this with your actual data
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data) Source.Add(item);
    }

    public void OnNavigatedFrom()
    {
    }
}