using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicAlarmClock
{

    public partial class MainPage : ContentPage
    {
        private bool runTimer = true;

        DateTime localDate;

        int alarmHour = 0;
        int alarmMinutes = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnHourEntryTensTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "") //nothing to check
                return;

            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;

            int hoursTens = Convert.ToInt32(newText);
            int hoursUnits = Convert.ToInt32(entryHourUnits.Text);

            // if Units is > 3 - then 0
            if (hoursUnits > 3 && hoursTens > 1)
            {
                // 0 or 1 is allowed for units
                ((Entry)sender).Text = "0";
            }
            // Tens can only be 0, 1 or 2
            else if (hoursTens > 2)
            {
                ((Entry)sender).Text = "0";
            }
            //  if (!successfulInput)
            //     entryHourTens.Focus();
        }

        private void OnHourTensEntry_Unfocused(object sender, EventArgs e)
        {
            if (entryHourTens.Text == "")
                entryHourTens.Text = "0";
        }

        void OnHourEntryUnitsTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "") //nothing to check
                return;

            //string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;

            int hoursUnits = Convert.ToInt32(newText);
            int hoursTens = Convert.ToInt32(entryHourTens.Text);
             
            if (hoursTens == 2 && hoursUnits > 3)
            {
                // 24 hour clock goes from 0 to 23
                ((Entry)sender).Text = "0";
            }
            // else it'll be 0 or 1, therefore 0 to 9 is allowed
        }

        private void OnHourUnitsEntry_Unfocused(object sender, EventArgs e)
        {
            if (entryHourUnits.Text == "")
                entryHourUnits.Text = "0";
        }

        void OnMinutesEntryTensTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "") //nothing to check
                return;

            //string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;

            int hours = Convert.ToInt32(newText);
            if (hours > 5)
            {
                // 0 to 5 only (0 to 50 minutes for 10s of minutes)
                ((Entry)sender).Text = "0";
            }
        }

        void OnMinutesEntryTensCompleted(object sender, EventArgs e)
        {
            if (entryMinutesTens.Text == "")
                entryMinutesTens.Text = "0";
        }

        private void OnMinutesTensEntry_Unfocused(object sender, EventArgs e)
        {
            if (entryMinutesTens.Text == "")
                entryMinutesTens.Text = "0";
        }

        void OnMinutesUnitsEntryCompleted(object sender, EventArgs e)
        {
            if (entryMinutesUnits.Text == "")
                entryMinutesUnits.Text = "0";
        }

        private void OnMinutesUnitsEntry_Unfocused(object sender, EventArgs e)
        {
            if (entryMinutesUnits.Text == "")
                entryMinutesUnits.Text = "0";
        }

        void OnSetAlarmButtonClicked(object sender, EventArgs e)
        {
            playMusic();

        }

        void OnStartButtonClicked(object sender, EventArgs e)
        {
            string sAlarmHour = "" + entryHourTens.Text + entryHourUnits.Text;
            alarmHour = Convert.ToInt32(sAlarmHour);
            string sAlarmMins = "" + entryMinutesTens.Text + entryMinutesUnits.Text;
            alarmMinutes = Convert.ToInt32(sAlarmMins);

            // Alarm active
            startAlarmButton.Text = sAlarmMins;

            runTimer = true;
            RunTimer();

        }

        void OnStopButtonClicked(object sender, EventArgs e)
        {
            // Alarm active
            startAlarmButton.Text = "Start";

            DependencyService.Get<AudioInterface>().StopAudioFile();

            runTimer = false;

        }

        private void RunTimer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                // do something every 60 seconds
                if (runTimer)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        localDate = DateTime.Now;
                        // Check the time
                        // Is it time to set the alarm off
                        if (localDate.Hour == alarmHour && localDate.Minute == alarmMinutes)
                            lblTest.Text = "DING DING DING";
                    });
                    return true;
                }
                titleLabel.Text = "Stopped";
                return false; // stop the timer
            });
        }

        private void entryMinutesUnits_Unfocused(object sender, FocusEventArgs e)
        {

        }

        public void playMusic()
        {
            //    CrossMediaManager.Current.Play("D:\\Projects\\APP Developer\\MusicAlarmClock\\MusicAlarmClock\\MusicAlarmClock\\MusicAlarmClock\\Sounds\\TestSound.mp3");
            DependencyService.Get<AudioInterface>().PlayAudioFile("TestSound.mp3");
        }

    }
}
