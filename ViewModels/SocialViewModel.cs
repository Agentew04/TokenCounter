﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenCounter.Models;
using TokenCounter.Services;

namespace TokenCounter.ViewModels;

[QueryProperty(nameof(AuthToken), "auth")]
[QueryProperty(nameof(Username), "user")]
public partial class SocialViewModel : BaseViewModel {

    readonly IConnectivity connectivity;
    readonly UserService userService;
    
    public SocialViewModel(IConnectivity connectivity, UserService userService) {
        this.connectivity = connectivity;
        this.userService = userService;
        Title = "Social";
    }

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string authToken;

    [ObservableProperty]
    bool isRefreshing;

    public ObservableCollection<User> Friends { get; } = new();

    [RelayCommand]
    async void GetFriends() {
        if (IsBusy)
            return;

        try {
            // check internet access
            if(connectivity.NetworkAccess != NetworkAccess.Internet) {
                await Shell.Current.DisplayAlert("No internet!", "Unable to find internet access! :(", "Ok");
                return;
            }

            IsBusy = true;
            var friends = userService.
            

        } catch (Exception ex){
            await Shell.Current.DisplayAlert("Error!", $"Error message: {ex.Message}", "Ok");
        } finally {
            IsBusy = false;
            // this is set to true when the user pulls the refresh view
            IsRefreshing = false;
        }
    }
}