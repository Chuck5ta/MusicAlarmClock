using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MusicAlarmClock
{
    public partial class MainPage : ContentPage
    {
        private bool runTimer = true;

        DateTime localDate;

        int alarmHour = 0;
        int alarmMinutes = 0;

        MusicOptions musicOptions;


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

        void OnSelectMusicOptionsButtonClicked(object sender, EventArgs e)
        {
            // Need to not create a new MusicOptions page, if one already exists!!!!
            if (musicOptions == null) // have we created the page already
            {
                musicOptions = new MusicOptions();
            }

            Application.Current.MainPage.Navigation.PushAsync(musicOptions);

            /*
            var path = DependencyService.Get<FileInterface>().GetExternalStoragePath();
            Console.WriteLine("DEBUG - Path: " + path);

            // Have the user select the music file
            string[] listOfFiles = DependencyService.Get<FileInterface>().GetFileList(path);

            if (listOfFiles == null)
            {
                Console.WriteLine("DEBUG Failed to load file list");
                return;
            }

            // iterate through the list and write them to the log
            foreach (string file in listOfFiles)
                Console.WriteLine("DEBUG - File: " + file);

            */
            //       playMusic();

        }

        void OnStartButtonClicked(object sender, EventArgs e)
        {
            DiscJockey();
            /*
            string sAlarmHour = "" + entryHourTens.Text + entryHourUnits.Text;
            alarmHour = Convert.ToInt32(sAlarmHour);
            string sAlarmMins = "" + entryMinutesTens.Text + entryMinutesUnits.Text;
            alarmMinutes = Convert.ToInt32(sAlarmMins);

            // Alarm active
            startAlarmButton.Text = sAlarmMins;

            runTimer = true;
            RunTimer();

            */

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
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                // do something every 5 seconds
                if (runTimer)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Check the time
                        // Is it time to set the alarm off
                        if (localDate.Hour == alarmHour && localDate.Minute == alarmMinutes)
                        {
                            lblTest.Text = "DING DING DING";
                            DiscJockey();
                        }
                    });
                    return true;
                }
                titleLabel.Text = "Stopped";
                return false; // stop the timer
            });
        }

        /*
         * This is used when the option for playing the songs randmonly is picked
         */
        public int GetRandomSong(int totalSongs)
        {
            Random song = new Random();

            return song.Next(totalSongs-1);
        }

        bool djPlay = true;
        bool playingSong = false;
        private void DiscJockey()
        {
            int totalSongs = musicOptions.pickMultipleSongs.multipleSongList.Count;

            // Decide on how the tracks are to be played
            // in sequence
            // random
            // repeat


            Console.WriteLine("-----======= Songs in the list START =======-----");
            foreach (var song in musicOptions.pickMultipleSongs.multipleSongList)
            {
                Console.WriteLine("Song: " + song);
            }
            Console.WriteLine("-----======= Songs in the list END =======-----");



            int index = 0;
            // If random, then pick a random song (index)
            if (musicOptions.playRandomSong)
            {
                index = GetRandomSong(totalSongs);
                playSong(index);
            }
            else
            {
                playSong(index);
                index++;
            }

            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
            {
                if (djPlay) // check if song is actually playing - have playSongs set a global
                {
                    // do something every 60 seconds
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (index < totalSongs && !playingSong)
                        {
                            // If random, then pick a random song (index)
                            if (musicOptions.playRandomSong)
                            {
                                index = GetRandomSong(totalSongs);
                                playSong(index);
                            }
                            else
                            {
                                playSong(index);
                                index++;
                            }
                        }
                        if (index == totalSongs)
                            djPlay = false; // stop the DJ
                    });
                    return true; // runs again, or false to stop
                }
                return false; // stop the timer
            });
        }

        private void playSong(int index)
        {
            playingSong = true;
    //        Console.WriteLine("AHHHHHHHHHHHHHHHHHHHHHH");
            int duration = 4 + (DependencyService.Get<AudioInterface>().PlayAudioFile(musicOptions.pickMultipleSongs.multipleSongList[index]) / 1000);
            Console.WriteLine("BOOT - SONG: " + musicOptions.pickMultipleSongs.multipleSongList[index]);
            Console.WriteLine("BOOT - SONG DURATION: " + duration);
            Device.StartTimer(new TimeSpan(0, 0, duration), () =>
            {
                playingSong = false;
                return false; // stop the timer
            });
        }

    }
}
