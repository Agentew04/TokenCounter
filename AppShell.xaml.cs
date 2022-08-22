using TokenCounter.Views;

namespace TokenCounter;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(TokenPage), typeof(TokenPage));
    }
}