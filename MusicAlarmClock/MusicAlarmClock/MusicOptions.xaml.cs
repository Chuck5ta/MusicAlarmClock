using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAlarmClock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicOptions : ContentPage
    {
        public MusicOptions()
        {
            InitializeComponent();
        }

        void OnPlaySingleTrackCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnPlayMultipleTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnPlayAllTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnPlayRandomTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnRepeatTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnIncreaseVolumeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        void OnBackButtonClicked(object sender, EventArgs e)
        {
            //   Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}