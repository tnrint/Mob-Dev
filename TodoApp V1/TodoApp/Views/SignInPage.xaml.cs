namespace TodoApp.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new AuthViewModel();
    }
}