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
        // Content pages
        public PickASong pickASong;
        public PickMultipleSongs pickMultipleSongs;

        public MusicOptions()
        {
            InitializeComponent();
        }

        void OnPlaySingleTrackCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Need to not create a new page object, if one already exists!!!!
            if (pickASong == null) // have we created the page already
            {
                pickASong = new PickASong(); // create a new PickASong content page
            }

            Application.Current.MainPage.Navigation.PushAsync(pickASong);
        }

        void OnPlayMultipleTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Need to not create a new page object, if one already exists!!!!
            if (pickMultipleSongs == null) // have we created the page already
            {
                pickMultipleSongs = new PickMultipleSongs(); // create a new PickASong content page
            }

            Application.Current.MainPage.Navigation.PushAsync(pickMultipleSongs);
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
            // pop the last page off of the stack (MainPage in this case)
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}