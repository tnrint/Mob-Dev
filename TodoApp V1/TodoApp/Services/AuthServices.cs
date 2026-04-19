using System.Net.Http.Json;
using TodoApp.Models;

public class AuthService
{
    private readonly HttpClient _httpClient = new HttpClient();

    private const string BaseUrl = "https://10.0.2.2/api/";

    public async Task<ApiResponse<UserData>> SignUp(SignUpRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(BaseUrl + "signup_action.php", request);

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<UserData>>();

        return result ?? new ApiResponse<UserData>
        {
            Success = false,
            Message = "Empty server response",
            Data = null
        };
    }

    public async Task<SignInResponse> SignIn(string email, string password)
    {
        var url = $"{BaseUrl}signin_action.php?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";

        var response = await _httpClient.GetAsync(url);

        var result = await response.Content.ReadFromJsonAsync<SignInResponse>();
        return result ?? new SignInResponse { Success = false, Message = "Empty server response" };
    }
}