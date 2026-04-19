using TodoApp.Models;

public class AuthViewModel
{
    private readonly AuthService _authService = new AuthService();

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }

    public Command SignInCommand => new Command(async () => await SignIn());
    public Command SignUpCommand => new Command(async () => await SignUp());

    private async Task SignIn()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Email and password are required", "OK");
            return;
        }

        var result = await _authService.SignIn(Email, Password);

        if (result.Success)
        {
            await Shell.Current.DisplayAlert("Success", "Welcome!", "OK");
            await Shell.Current.GoToAsync("//TodoPage");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", result.Message, "OK");
        }
    }

    private async Task SignUp()
    {
        var result = await _authService.SignUp(new SignUpRequest
        {
            first_name = FirstName,
            last_name = LastName,
            email = Email,
            password = Password,
            confirm_password = ConfirmPassword
        });

        var page = Application.Current?.Windows.FirstOrDefault()?.Page;

        if (page != null)
        {
            await page.DisplayAlert("Result", result.Message, "OK");
        }
    }
}