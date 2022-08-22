using CommunityToolkit.Maui;
using TokenCounter.ViewModels;
using TokenCounter.Views;

namespace TokenCounter;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<TokenViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<TokenPage>();

        return builder.Build();
    }
}