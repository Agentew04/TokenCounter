using TokenCounter.ViewModels;

namespace TokenCounter.Views;

public partial class LoginPage : ContentPage {
	public LoginPage(LoginViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;
	}

	private void MoveFocusToPassword(object sender, EventArgs e) {
		PasswordEntry.Focus();
    }
}