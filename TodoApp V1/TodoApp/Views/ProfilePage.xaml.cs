using Microsoft.Maui.Controls;

namespace TodoApp.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    // Logout button click
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        // Navigate back to SignInPage
        // This works with AppShell navigation
        await Navigation.PushAsync(new SignInPage());

        // Optional: remove current ProfilePage from navigation stack
        Navigation.RemovePage(this);
    }
}