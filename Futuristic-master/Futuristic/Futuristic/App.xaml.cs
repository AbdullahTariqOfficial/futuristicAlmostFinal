using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Futuristic.Services;
using Futuristic.Views;
using System.Threading.Tasks;

namespace Futuristic
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
           // MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            MainPage = new NavigationPage(new SplashPage());

            await Task.Delay(5000);

            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
