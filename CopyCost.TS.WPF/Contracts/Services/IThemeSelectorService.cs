using CopyCost.TS.WPF.Models;

namespace CopyCost.TS.WPF.Contracts.Services;

public interface IThemeSelectorService
{
    void InitializeTheme();

    void SetTheme(AppTheme theme);

    AppTheme GetCurrentTheme();
}
