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
        private bool successfullInput;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnHourEntryTensTextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime localDate = DateTime.Now;

            successfullInput = true;

            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;
            if (newText != "")
            {
                int hoursTens = Convert.ToInt32(newText);
                int hoursUnits = Convert.ToInt32(entryHourUnits.Text);

                // if Units is > 3 - then 0
                if (hoursUnits > 3)
                {
                    // 0 or 1 is allowed
                    if (hoursTens > 1)
                    {
                        // invalid entry, set it back to the original value!
                        ((Entry)sender).Text = "0";
                        successfullInput = false;
                    }
                    else
                        entryHourUnits.Focus();
                }
                // Tens can only be 0, 1 or 2
                else if (hoursTens > 2)
                {
                    // invalid entry, set it back to the original value!
                    ((Entry)sender).Text = "0";
                    successfullInput = false;
                    titleLabel.Text = successfullInput.ToString();
                }
                // if Units is > 1 - then allow 2
                else if (hoursUnits > 1) // it's 2
                {
                    if (hoursTens > 2) // must be 0, 1 or 2
                    {
                       // invalid entry, set it back to the original value!
                       ((Entry)sender).Text = "0";
                       successfullInput = false;
                    }
                    else
                       entryHourUnits.Focus();
                }
                else // Tens is 0
                    entryHourUnits.Focus();
            }
        }

        void OnHourEntryUnitsTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;
            if (newText != "")
            {
                int hoursUnits = Convert.ToInt32(newText);
                int hoursTens = Convert.ToInt32(entryHourTens.Text);
                //entryHourTens
                // if tens is 1
                if (hoursTens == 1)
                {
                    if (hoursUnits > 2)
                    {
                        // invalid entry, set it back to the original value!
                        ((Entry)sender).Text = oldText;
                    }
                }
                else if (hoursTens == 2)
                {
                    // if tens is 2
                    if (hoursUnits > 3)
                    {
                        // invalid entry, set it back to the original value!
                        ((Entry)sender).Text = oldText;
                    }
                }
                // else it'll be 0, therefore 0 to 9 is allowed
            }
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;
            if (newText != "")
            {
                int hours = Convert.ToInt32(newText);
                if (hours > 3)
                {
                    // invalid entry, set it back to the original value!
                    ((Entry)sender).Text = oldText;
                }
            }
        }
        void OnMinutesEntryTensTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            ((Entry)sender).Text = newText;
            if (newText != "")
            {
                int hours = Convert.ToInt32(newText);
                if (hours > 5)
                {
                    // invalid entry, set it back to the original value!
                    ((Entry)sender).Text = oldText;
                }
            }
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

        void OnStartButtonClicked(object sender, EventArgs e)
        {
            // Alarm active
            startAlarmButton.Text = "ACTIVE";

            runTimer = true;
            RunTimer();

        }

        void OnStopButtonClicked(object sender, EventArgs e)
        {
            // Alarm active
            startAlarmButton.Text = "Start";

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
                    // Check the time
                    // Is it time to set the alarm off
                    titleLabel.Text = "Tick";
                    });
                    return true;
                }
                titleLabel.Text = "Stopped";
                return false; // stop the timer
            });
        }


    }
}
