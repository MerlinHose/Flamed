using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flamed.Pages;
using Flamed.Scripts.Crypt;

namespace Flamed.Scripts.View
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string email = "admin@flamed.net"; // Default for testing

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string password;

        [ObservableProperty]
        private bool rememberMe;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private bool hasError;

        public bool IsNotBusy => !IsBusy;

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task Login()
        {
            try
            {
                IsBusy = true;
                HasError = false;
                ErrorMessage = string.Empty;

                // Debug output
                Console.WriteLine($"Attempting login with: {Email}");

                var hashedInput = Hash.GetHashSha256(Password);
                var correctHash = Hash.GetHashSha256("admin"); // Pre-hashed correct password

                if (Email.Equals("admin@flamed.net", StringComparison.OrdinalIgnoreCase) &&
                    hashedInput == correctHash)
                {
                    if (RememberMe)
                    {
                        Preferences.Set("RememberMe", true);
                        Preferences.Set("StoredEmail", Email);
                    }

                    await Shell.Current.GoToAsync("//MainPage", animate: true);
                }
                else
                {
                    ErrorMessage = "Invalid credentials";
                    HasError = true;
                    await Shell.Current.DisplayAlert("Error", ErrorMessage, "OK");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Login failed. Please try again.";
                HasError = true;
                Console.WriteLine($"Login error: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void ToggleRememberMe() => RememberMe = !RememberMe;

        [RelayCommand]
        private async Task ForgotPassword() =>
            await Shell.Current.DisplayAlert("Help", "Contact admin@flamed.net", "OK");

        [RelayCommand]
        private async Task NavigateToRegister() =>
            await Shell.Current.GoToAsync(nameof(RegisterPage), animate: true);

        private bool CanLogin() =>
            !string.IsNullOrWhiteSpace(Email) &&
            Email.Contains("@", StringComparison.Ordinal) &&
            !string.IsNullOrWhiteSpace(Password) &&
            Password.Length >= 4;

        public void LoadRememberedUser()
        {
            if (Preferences.Get("RememberMe", false))
            {
                Email = Preferences.Get("StoredEmail", "admin@flamed.net");
                RememberMe = true;
            }
        }
    }
}