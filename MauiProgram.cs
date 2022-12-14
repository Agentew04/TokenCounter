using CommunityToolkit.Maui;
using TokenCounter.Services;
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

        builder.Services.AddSingleton(Connectivity.Current)
            .AddSingleton<UserService>()
            .AddSingleton<TokenService>();

        builder.Services.AddSingleton<MainViewModel>()
            .AddTransient<LoginViewModel>()
            .AddTransient<RegisterViewModel>()
            .AddTransient<SocialViewModel>();

        builder.Services.AddSingleton<MainPage>()
            .AddTransient<LoginPage>()
            .AddTransient<RegisterPage>()
            .AddTransient<SocialPage>();

        return builder.Build();
    }
}