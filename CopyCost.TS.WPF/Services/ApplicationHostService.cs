using System.Windows;
using CopyCost.TS.WPF.Contracts.Activation;
using CopyCost.TS.WPF.Contracts.Services;
using CopyCost.TS.WPF.Contracts.Views;
using CopyCost.TS.WPF.Features.Payments;
using Microsoft.Extensions.Hosting;

namespace CopyCost.TS.WPF.Services;

public class ApplicationHostService : IHostedService
{
    private readonly IEnumerable<IActivationHandler> _activationHandlers;
    private readonly INavigationService _navigationService;
    private readonly IPersistAndRestoreService _persistAndRestoreService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IThemeSelectorService _themeSelectorService;
    private bool _isInitialized;
    private IShellWindow _shellWindow;

    public ApplicationHostService(IServiceProvider serviceProvider, IEnumerable<IActivationHandler> activationHandlers,
        INavigationService navigationService, IThemeSelectorService themeSelectorService,
        IPersistAndRestoreService persistAndRestoreService)
    {
        _serviceProvider = serviceProvider;
        _activationHandlers = activationHandlers;
        _navigationService = navigationService;
        _themeSelectorService = themeSelectorService;
        _persistAndRestoreService = persistAndRestoreService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Initialize services that you need before app activation
        await InitializeAsync();

        await HandleActivationAsync();

        // Tasks after activation
        await StartupAsync();
        _isInitialized = true;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _persistAndRestoreService.PersistData();
        await Task.CompletedTask;
    }

    private async Task InitializeAsync()
    {
        if (!_isInitialized)
        {
            _persistAndRestoreService.RestoreData();
            _themeSelectorService.InitializeTheme();
            await Task.CompletedTask;
        }
    }

    private async Task StartupAsync()
    {
        if (!_isInitialized) await Task.CompletedTask;
    }

    private async Task HandleActivationAsync()
    {
        var activationHandler = _activationHandlers.FirstOrDefault(h => h.CanHandle());

        if (activationHandler != null) await activationHandler.HandleAsync();

        await Task.CompletedTask;

        if (Application.Current.Windows.OfType<IShellWindow>().Count() == 0)
        {
            // Default activation that navigates to the apps default page
            _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
            _navigationService.Initialize(_shellWindow.GetNavigationFrame());
            _shellWindow.ShowWindow();
            _navigationService.NavigateTo(typeof(PaymentsViewModel).FullName);
            await Task.CompletedTask;
        }
    }
}