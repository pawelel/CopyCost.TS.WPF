using System.Windows.Controls;

namespace CopyCost.TS.WPF.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
