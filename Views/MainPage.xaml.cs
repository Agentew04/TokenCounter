using TokenCounter.ViewModels;

namespace TokenCounter.Views;

public partial class MainPage : ContentPage {
    public MainPage(MainViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
    }
}