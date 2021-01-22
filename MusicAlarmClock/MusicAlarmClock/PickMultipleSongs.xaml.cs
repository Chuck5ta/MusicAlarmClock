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
    public partial class PickMultipleSongs : ContentPage
    {
        public Dictionary<string, string> MusicDictionary;
        public string[] MusicFileNames;
        public string[] musicPaths;

        private string pathToMusic;
        public IList<string> multipleSongList;

        public PickMultipleSongs()
        {
            InitializeComponent();

            MusicDictionary = new Dictionary<string, string>();  // filename, path+filename
            this.BindingContext = this;
            LoadTheFiles();

            // used for when more than one music file is to be played
            multipleSongList = new List<string>();
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
                    MusicFileNames[index] = MusicFileNames[index].Replace(pathToMusic, "");
                }
            }
            else
                Console.WriteLine("DEBUG - No songs found!");

            MusicFilesList.ItemsSource = MusicFileNames;
        }

        void OnBackButtonClicked(object sender, EventArgs e)
        {
            // store the list of songs
            foreach (var item in MusicFilesList.SelectedItems)
            {
                multipleSongList.Add(item.ToString());
            }

            // pop the last page off of the stack (MusicOptions page in this case)
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}