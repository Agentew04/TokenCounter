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

public partial class LoginViewModel : BaseViewModel
{
	// used to check network for login
	IConnectivity _connectivityService;
	UserService _userService;
	public LoginViewModel(IConnectivity connectivityService, UserService userService)
	{
		Title = "Login";
        _connectivityService = connectivityService;
		_userService = userService;
	}

	[ObservableProperty]
	string username = string.Empty;

	[ObservableProperty]
	string password = string.Empty;

	[ICommand]
	async Task GoToRegisterAsync()
	{
		await Shell.Current.GoToAsync($"../{nameof(RegisterPage)}");
	}

	[ICommand]
	async Task TryLoginAsync()
	{
		Username = "rodrigo";
		Debug.WriteLine($"trying to navigate back with {Username}");
		await Shell.Current.GoToAsync($"..?Username={Username}", true);
	}
}
