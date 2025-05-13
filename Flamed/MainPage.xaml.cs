using Flamed.Scripts.View;

namespace Flamed;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
    }
}