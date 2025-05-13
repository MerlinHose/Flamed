using Flamed.Scripts.View;

namespace Flamed.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

        BindingContext = new LoginViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as LoginViewModel)?.LoadRememberedUser();
    }
}