using System.Windows.Controls;

namespace CopyCost.TS.WPF.Contracts.Services;

public interface INavigationService
{
    bool CanGoBack { get; }
    event EventHandler<string> Navigated;

    void Initialize(Frame shellFrame);

    bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false);

    void GoBack();

    void UnsubscribeNavigation();

    void CleanNavigation();
}