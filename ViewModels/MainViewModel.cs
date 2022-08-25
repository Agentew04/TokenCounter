using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TokenCounter.Views;

namespace TokenCounter.ViewModels;

[QueryProperty(nameof(Username), nameof(Username))]
public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "";
        Username = string.Empty;
    }

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsLoggedIn))]
    [AlsoNotifyChangeFor(nameof(IsNotLoggedIn))]
    string username;

    public bool IsLoggedIn => !string.IsNullOrEmpty(Username);
    public bool IsNotLoggedIn => !IsLoggedIn;


    [ObservableProperty]
    int tokens = 0;

    [ICommand]
    async Task AddTokens(){
        if (IsBusy)
            return;
        IsBusy = true;

        string response = await Application.Current.MainPage.DisplayPromptAsync("Amount",
            "Type the amount of tokens to be added",
            "Add", "Cancel", "0", 7);

        // sanitize string
        if (response is null)
        {
            IsBusy = false;
            return;
        }
        response = new string(response.Where(c => char.IsDigit(c)).ToArray());
        response = response == "" ? "0" : response;

        // try parse to not overflow/underflow
        bool parsed = int.TryParse(response, out int tokenAmount);
        if (!parsed)
            tokenAmount = 0;
        tokenAmount = Math.Abs(tokenAmount);
        Tokens += tokenAmount;
        string message = tokenAmount > 0 ? ($"Added {tokenAmount} " + (tokenAmount > 1 ? "tokens." : "token.")) :
            "Cannot add 0 tokens!";
        IsBusy = false;
        using var toast = Toast.Make(message);
        await toast.Show();
    }

    [ICommand]
    async Task RemoveTokens(){
        if (IsBusy)
            return;
        IsBusy = true;
        string response = await Application.Current.MainPage.DisplayPromptAsync("Amount",
            "Type the amount of tokens to be removed",
            "Remove", "Cancel", "0", 7);

        // sanitize string
        if (response is null)
        {
            IsBusy = false;
            return;
        }
        response = new string(response.Where(c => char.IsDigit(c)).ToArray());
        response = response == "" ? "0" : response;

        bool parsed = int.TryParse(response, out int tokenAmount);
        if (!parsed)
            tokenAmount = 0;
        tokenAmount = Math.Abs(tokenAmount);
        Tokens -= tokenAmount;
        string message = tokenAmount > 0 ? ($"Removed {tokenAmount} " + (tokenAmount > 1 ? "tokens." : "token.")) :
            "Cannot remove 0 tokens!";
        IsBusy = false;
        using var toast = Toast.Make(message);
        await toast.Show();
    }

    [ICommand]
    async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    [ICommand]
    void Logout()
    {
        Username = string.Empty;
        Tokens = 0;
    }

}
