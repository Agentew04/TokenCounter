using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TokenCounter.Views;

namespace TokenCounter.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        public bool isLoggedIn = false;

        [ObservableProperty]
        public string username = String.Empty;

        [ObservableProperty]
        public int tokens = 0;

        [ICommand]
        async Task AddTokens(){
            string response = await Application.Current.MainPage.DisplayPromptAsync("Amount",
                "Type the amount of tokens to be added",
                "Add", "Cancel",
                "0", -1, Keyboard.Numeric);
            bool canParse = int.TryParse(response, out int tokenAmont);
            if (!canParse)
                return;
            tokenAmont = Math.Abs(tokenAmont);
            Tokens += tokenAmont;
            await Application.Current.MainPage.DisplaySnackbar(
                $"Added {tokenAmont} " + (tokenAmont > 1 ? "tokens." : "token."),
                duration: new TimeSpan(0, 0, 5));
        }

        [ICommand]
        async Task RemoveTokens(){
            string response = await Application.Current.MainPage.DisplayPromptAsync("Amount",
                "Type the amount of tokens to be removed",
                "Remove", "Cancel",
                "0", -1, Keyboard.Numeric);
            bool canParse = int.TryParse(response, out int tokenAmont);
            if (!canParse)
                return;
            tokenAmont = Math.Abs(tokenAmont);
            Tokens -= tokenAmont;
            await Application.Current.MainPage.DisplaySnackbar(
                $"Removed {tokenAmont} " + (tokenAmont > 1 ? "tokens." : "token."),
                duration: new TimeSpan(0, 0, 5));
        }
    }
}
