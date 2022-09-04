using TokenCounter.ViewModels;

namespace TokenCounter.Views;

public partial class SocialPage : ContentPage {
	public SocialPage(SocialViewModel vm) {
		InitializeComponent();
		BindingContext = vm;
	}
}