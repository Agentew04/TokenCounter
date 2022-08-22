using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TokenCounter.Views;

namespace TokenCounter.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public bool isWorking;

        [ICommand]
        async Task Login()
        {
            if (IsWorking)
                return;
            IsWorking = true;
            Debug.Write($"Logging in as {Username}");
            await Task.Delay(1000);
            Debug.Write(".");
            await Task.Delay(1000);
            Debug.Write(".");
            await Task.Delay(1000);
            Debug.WriteLine(".");
            Debug.WriteLine($"Logged in as {Username}");

            // todo add login method
            bool loggedIn = true;
            if (loggedIn)
            {
                await Shell.Current.GoToAsync(nameof(TokenPage));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed to login", "Wrong username or password!", "Back");
            }
            IsWorking = false;
        }

        [ICommand]
        async Task Register(){
            Debug.WriteLine($"Registering in as {Username}");
            await Task.Delay(1000);
            Debug.Write(".");
            await Task.Delay(1000);
            Debug.Write(".");
            await Task.Delay(1000);
            Debug.Write(".\n");
        }
    }
}
