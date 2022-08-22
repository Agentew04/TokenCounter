using TokenCounter.Views;

namespace TokenCounter;

public partial class App : Application {
    public App() {
        InitializeComponent();

        MainPage = new AppShell();
    }
}