using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoApp.pages
{
    public partial class SignInViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {

        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;


        public SignInViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [RelayCommand]
        private async Task SignIn()
        {
            await _authClient.SignInWithEmailAndPasswordAsync(_email, _password);

            // Navigate to main app (ToDo tab) after successful sign in
            await Shell.Current.GoToAsync("//Todo");
        }

        [RelayCommand]
        private async Task NavigateToSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }



    }
}
