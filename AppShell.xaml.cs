﻿using TokenCounter.Views;

namespace TokenCounter;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    }
}