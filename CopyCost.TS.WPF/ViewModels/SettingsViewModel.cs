﻿using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CopyCost.TS.WPF.Contracts.Services;
using CopyCost.TS.WPF.Contracts.ViewModels;
using CopyCost.TS.WPF.Models;
using CopyCost.TS.WPF.Properties;
using Microsoft.Extensions.Options;

namespace CopyCost.TS.WPF.ViewModels;

// TODO: Change the URL for your privacy policy in the appsettings.json file, currently set to https://YourPrivacyUrlGoesHere
public class SettingsViewModel : ObservableObject, INavigationAware
{
    private readonly AppConfig _appConfig;
    private readonly IApplicationInfoService _applicationInfoService;
    private readonly ISystemService _systemService;
    private readonly IThemeSelectorService _themeSelectorService;
    private ICommand _privacyStatementCommand;
    private ICommand _setThemeCommand;
    private AppTheme _theme;
    private string _versionDescription;

    public SettingsViewModel(IOptions<AppConfig> appConfig, IThemeSelectorService themeSelectorService,
        ISystemService systemService, IApplicationInfoService applicationInfoService)
    {
        _appConfig = appConfig.Value;
        _themeSelectorService = themeSelectorService;
        _systemService = systemService;
        _applicationInfoService = applicationInfoService;
    }

    public AppTheme Theme
    {
        get => _theme;
        set => SetProperty(ref _theme, value);
    }

    public string VersionDescription
    {
        get => _versionDescription;
        set => SetProperty(ref _versionDescription, value);
    }

    public ICommand SetThemeCommand => _setThemeCommand ?? (_setThemeCommand = new RelayCommand<string>(OnSetTheme));

    public ICommand PrivacyStatementCommand =>
        _privacyStatementCommand ?? (_privacyStatementCommand = new RelayCommand(OnPrivacyStatement));

    public void OnNavigatedTo(object parameter)
    {
        VersionDescription = $"{Resources.AppDisplayName} - {_applicationInfoService.GetVersion()}";
        Theme = _themeSelectorService.GetCurrentTheme();
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnSetTheme(string themeName)
    {
        var theme = (AppTheme)Enum.Parse(typeof(AppTheme), themeName);
        _themeSelectorService.SetTheme(theme);
    }

    private void OnPrivacyStatement()
    {
        _systemService.OpenInWebBrowser(_appConfig.PrivacyStatement);
    }
}