using Microsoft.Maui.Controls;
using TodoApp.Views.pages;

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
        // Navigate back to the SignIn route (clears the current navigation)
        await Shell.Current.GoToAsync("//SignIn");
    }
}