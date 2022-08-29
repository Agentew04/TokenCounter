using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenCounter.ViewModels;

public partial class RegisterViewModel : BaseViewModel {
	public RegisterViewModel() {
		Title = "Register Account";
	}

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string passwordAgain;

    [RelayCommand]
    async Task TryRegisterAsync() {
        Username = "rodrigo";
        Debug.WriteLine($"trying to navigate back with {Username}");
        await Shell.Current.GoToAsync($"..?Username={Username}");
    }
}
