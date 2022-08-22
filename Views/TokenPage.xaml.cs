using TokenCounter.ViewModels;

namespace TokenCounter.Views;

public partial class TokenPage : ContentPage
{
	public TokenPage(TokenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}