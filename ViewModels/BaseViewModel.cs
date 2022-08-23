using CommunityToolkit.Mvvm.ComponentModel;

namespace TokenCounter.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy = false;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    string title = "";
}
