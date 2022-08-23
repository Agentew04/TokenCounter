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

            // sanitize string
            response = new string(response.Where(c => char.IsDigit(c)).ToArray());
            response = response == "" ? "0" : response;

            int tokenAmont = int.Parse(response);
            if (!canParse)
                return;
            tokenAmont = Math.Abs(tokenAmont);
            Tokens += tokenAmont;
            using var toast = Toast.Make($"Added {tokenAmont} " + (tokenAmont > 1 ? "tokens." : "token."));
            await toast.Show();
        }

        [ICommand]
        async Task RemoveTokens(){
            string response = await Application.Current.MainPage.DisplayPromptAsync("Amount",
                "Type the amount of tokens to be removed",
                "Remove", "Cancel",
                "0", -1, Keyboard.Numeric);

            // sanitize string
            response = new string(response.Where(c => char.IsDigit(c)).ToArray());
            response = response == "" ? "0" : response;

            int tokenAmont = int.Parse(response);
            tokenAmont = Math.Abs(tokenAmont);
            Tokens -= tokenAmont;
            using var toast = Toast.Make($"Removed {tokenAmont} " + (tokenAmont > 1 ? "tokens." : "token."));
            await toast.Show();
        }
    }
}
