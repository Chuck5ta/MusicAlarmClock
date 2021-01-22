using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAlarmClock
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickASong : ContentPage
    {
        public Dictionary<string, string> MusicDictionary; 
        public string[] MusicFileNames;
        public string[] musicPaths;

        private string pathToMusic;
        private string selectedSong; // this will be the song that will be played

        public PickASong()
        {
            InitializeComponent();

            MusicDictionary = new Dictionary<string, string>();  // filename, path+filename
            this.BindingContext = this;
            LoadTheFiles();
        }

        public void LoadTheFiles()
        {
            pathToMusic = DependencyService.Get<FileInterface>().GetExternalStoragePath();
            if (pathToMusic != null)
            {
                musicPaths = DependencyService.Get<FileInterface>().GetFileList(pathToMusic);
                MusicFileNames = musicPaths; // creates MusicFileNames object
            }
            else
                Console.WriteLine("DEBUG - NULL PATH: ");

            pathToMusic = pathToMusic + "/";
            if (musicPaths.Length > 0)
            {
                for (int index = 0; index < musicPaths.Length; index++)
                {
                    // store the filename as a key and the path (incl filename) as the value
                    MusicFileNames[index] = musicPaths[index].Replace(pathToMusic, "");
                    MusicDictionary.Add(MusicFileNames[index], musicPaths[index]);
                }
            }
            else
                Console.WriteLine("DEBUG - No songs found!");

            MusicFilesList.ItemsSource = MusicFileNames;
        }

        public string GetSong()
        {
            return selectedSong;
        }

        void OnBackButtonClicked(object sender, EventArgs e)
        {
            // pop the last page off of the stack (MusicOptions page in this case)
            Application.Current.MainPage.Navigation.PopAsync();
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedSong = e.SelectedItem as string;
            Console.WriteLine("TESTY - Selected file: " + selectedSong);

            // need to pick out the song from the Dictionary

            string fullPathAndSong;
            if (MusicDictionary.TryGetValue(selectedSong, out fullPathAndSong))
            {
                Console.WriteLine(fullPathAndSong);
            }

            selectedSong = fullPathAndSong;
        }
    }
}