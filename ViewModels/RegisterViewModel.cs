using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCounter.Services;

namespace TokenCounter.ViewModels;

public partial class RegisterViewModel : BaseViewModel {
    readonly UserService _userService;
    
	public RegisterViewModel(UserService userService) {
		Title = "Register Account";
        _userService = userService;
	}

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string passwordAgain;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsError))]
    string errorMessage;

    public bool IsError => string.IsNullOrEmpty(errorMessage);

    [RelayCommand]
    async Task TryRegister() {
        if (IsBusy)
            return;
        IsBusy = true;

        if(password != passwordAgain) {
            ErrorMessage = "Passwords don't match!";
            IsBusy = false;
            return;
        }
        var res = await _userService.Register(Username, Password);
        
        bool goBack = false;
        if(res.status == RegisterStatus.Success) {
            goBack = true;
            ErrorMessage = "";
            Debug.WriteLine($"going back to main with ({Username}, {res})");
        } else {
            switch (res.status) {
                case RegisterStatus.UserAlreadyExists:
                    ErrorMessage = "User already exists!";
                    break;
                case RegisterStatus.InvalidUsername:
                    ErrorMessage = "Invalid username!";
                    break;
                case RegisterStatus.InvalidPassword:
                    ErrorMessage = "Invalid password!";
                    break;
            }
        }
        IsBusy = false;
        if(goBack)
            await Shell.Current.GoToAsync($"..?user={Username}&auth={res}", true);
    }
}
