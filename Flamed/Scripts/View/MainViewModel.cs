using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flamed.Pages;

namespace Flamed.Scripts.View
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private Microsoft.Maui.Controls.View _currentPage;

        public MainViewModel()
        {
            _currentPage = new LoginPage().Content;
        }

        [RelayCommand]
        private void NavigateToLogin() => CurrentPage = new LoginPage().Content;

        [RelayCommand]
        private void NavigateToHome() => CurrentPage = new HomePage().Content;
    }
}