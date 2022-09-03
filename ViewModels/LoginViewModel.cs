using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCounter.Services;
using TokenCounter.Views;

namespace TokenCounter.ViewModels;

public partial class LoginViewModel : BaseViewModel {
    // used to check network for login
    readonly IConnectivity _connectivityService;
	readonly UserService _userService;
	public LoginViewModel(IConnectivity connectivityService, UserService userService) {
		Title = "Login";
        _connectivityService = connectivityService;
		_userService = userService;
	}

	[ObservableProperty]
	string username = "";

	[ObservableProperty]
	string password = "";

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsError))]
	public string errorMessage = "";

	public bool IsError => string.IsNullOrEmpty(ErrorMessage);

	[RelayCommand]
	async Task GoToRegister() {
		await Shell.Current.GoToAsync($"../{nameof(RegisterPage)}");
	}

	[RelayCommand]
	async Task TryLogin() {
		if (IsBusy)
			return;
		IsBusy = true;
		var res = await _userService.Login(Username, Password);

		if(string.IsNullOrEmpty(res)) {
			ErrorMessage = "Wrong password!";
			IsBusy = false;
			return;
		}
		ErrorMessage = "";
		Debug.WriteLine($"going back to main with ({Username}, {res})");

		IsBusy = false;
		await Shell.Current.GoToAsync($"..?user={Username}&auth={res}", true);
	}
}
