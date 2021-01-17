using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAlarmClock
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BackgroundColor = Color.Beige,
                BarTextColor = Color.Black
            };
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
