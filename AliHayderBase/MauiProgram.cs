using Microsoft.Extensions.Logging;
using AliHayderBase.Shared.Services;
using AliHayderBase.Services;
using AliHayderBase.Shared.Core.Services;
using AliHayderBase.Shared.Core.Interfaces;

namespace AliHayderBase;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the AliHayderBase.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        // NavigationTracker
        builder.Services.AddSingleton<INavigationTracker, NavigationTracker>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
