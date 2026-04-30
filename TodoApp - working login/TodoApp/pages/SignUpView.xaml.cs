using TodoApp.pages;

namespace TodoApp.Views.pages;

public partial class SignUpView : ContentPage
{
	public SignUpView(SignUpViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}