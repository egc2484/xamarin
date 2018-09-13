using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mobile1
{
    public partial class App : Application
    {
        //public const string webserviceurl = "https://cloud-services.azurewebsites.net/api/products";
        public const string webserviceurl = "https://cloud-services.azurewebsites.net/";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
