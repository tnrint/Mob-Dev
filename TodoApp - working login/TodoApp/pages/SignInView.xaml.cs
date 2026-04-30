using TodoApp.pages;

namespace TodoApp.Views.pages;

public partial class SignInView : ContentPage
{
    public SignInView()
    {
    }

    public SignInView(SignInViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
		}
}