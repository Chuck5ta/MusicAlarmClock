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
        public PickMultipleSongs pickMultipleSongs;

        public bool playRandomSong = false;

        public MusicOptions()
        {
            InitializeComponent();
        }

        void OnSelectSongsButtonClicked(object sender, EventArgs e)
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
            playRandomSong = !playRandomSong;
        }

        void OnRepeatTracksCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
        }

        /*
         * Incrementally increases the volume
         */
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