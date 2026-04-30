using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using TodoApp.pages;
using TodoApp.Views;
using TodoApp.Views.pages;

namespace TodoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

           

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey= "AIzaSyCOtMSqWln-btrekXDXa19axI2ArQvKJP0",
                AuthDomain = "todo-14f3f.firebaseapp.com",
                Providers = new FirebaseAuthProvider[] { 
                    new EmailProvider()
                }

            }));

            builder.Services.AddSingleton<SignInViewModel>();
            builder.Services.AddSingleton<SignInView>();   
            builder.Services.AddSingleton<SignUpViewModel>();
            builder.Services.AddSingleton<SignUpView>();    
#endif

            return builder.Build();
        }
    }
}
