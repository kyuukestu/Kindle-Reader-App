using System;
using mobile_library.Helpers;
using mobile_library.ViewsPages;
using Plugin.FirebasePushNotification;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_library
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            //MainPage = new NavigationPage( new MainTabbedView());

            //MainPage = new NavigationPage(new LibraryView());
            //var createlibrarytable = new CreateLibraryTable().CreateTable();

            string username = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(username))
            {
                MainPage = new LoginSignupView();
            }
            else
            {
                MainPage = new MainTabbedView();
            }


            // Token event
            //CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            //};
            //// Push message received event
            //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            //{

            //    System.Diagnostics.Debug.WriteLine("Received");

            //};
            ////Push message received event
            //CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Opened");
            //    foreach (var data in p.Data)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
            //    }

            //};
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
