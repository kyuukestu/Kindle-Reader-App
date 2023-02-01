using System;
using System.Threading.Tasks;
using mobile_library.ViewsPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class LogoutViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; set; }
        public Command HomeCommand { get; set; }


        public LogoutViewModel()
        {
            LogoutCommand = new Command(async () => await LogoutUserAsync());
            HomeCommand = new Command(async () => await GoHomeAsync());

        }

        private async Task LogoutUserAsync()
        {
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginSignupView());
        }

        private async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());

            //await Application.Current.MainPage.DisplayAlert("Library", BookAuthor, "OK");

        }
    }
}
