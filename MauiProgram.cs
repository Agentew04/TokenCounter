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

        // to check if the device has access to internet
        builder.Services.AddSingleton(Connectivity.Current);

        builder.Services.AddSingleton<MainViewModel>()
            .AddTransient<LoginViewModel>()
            .AddTransient<RegisterViewModel>();

        builder.Services.AddSingleton<MainPage>()
            .AddTransient<LoginPage>()
            .AddTransient<RegisterPage>();

        return builder.Build();
    }
}