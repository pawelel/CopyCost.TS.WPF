using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using CopyCost.TS.WPF.Contracts.Services;
using CopyCost.TS.WPF.Contracts.Views;
using CopyCost.TS.WPF.Features.Categories;
using CopyCost.TS.WPF.Features.Customers;
using CopyCost.TS.WPF.Features.Payments;
using CopyCost.TS.WPF.Features.Settings;
using CopyCost.TS.WPF.Features.Shell;
using CopyCost.TS.WPF.Models;
using CopyCost.TS.WPF.Services;
using CopyCost.TS.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CopyCost.TS.WPF;

public partial class App : Application
{
    private IHost _host;

    public T GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        _host = Host.CreateDefaultBuilder(e.Args)
            .ConfigureAppConfiguration(c => { c.SetBasePath(appLocation); })
            .ConfigureServices(ConfigureServices)
            .Build();
        // Add the dispatcher unhandled exception handler
        DispatcherUnhandledException += OnDispatcherUnhandledException;
        await _host.StartAsync();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // TODO: Register your services, viewmodels and pages here

        // App Host
        services.AddHostedService<ApplicationHostService>();

        // Activation Handlers

        // Core Services
        services.AddSingleton<IFileService, FileService>();

        // Services
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<ISystemService, SystemService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddMediator(options=> options.ServiceLifetime = ServiceLifetime.Transient);
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<ISampleDataService, SampleDataService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // Views and ViewModels
        services.AddTransient<IShellWindow, ShellWindow>();
        services.AddTransient<ShellViewModel>();

        services.AddTransient<PaymentsViewModel>();
        services.AddTransient<PaymentsPage>();

        services.AddTransient<CustomersViewModel>();
        services.AddTransient<CustomersPage>();

        services.AddTransient<CategoriesViewModel>();
        services.AddTransient<CategoriesPage>();

        services.AddTransient<SettingsViewModel>();
        services.AddTransient<SettingsPage>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        _host = null;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // Handle the exception here
        e.Handled = true; // set to true to indicate that the exception has been handled
        MessageBox.Show($"Unhandled exception occurred: {e.Exception}");
    }
}