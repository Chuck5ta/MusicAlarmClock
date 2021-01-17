using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;
using MusicAlarmClock.Droid;
using System.Collections.Generic;
using System.IO;

[assembly: Dependency(typeof(FileService))]
namespace MusicAlarmClock.Droid
{
    class FileService : FileInterface
    {

        public FileService()
        {
        }

        public bool IsExternalStorageAvailable()
        {
            // Is there an external storage?
            bool isMounted = Environment.MediaMounted.Equals(Environment.ExternalStorageState);
            Android.Util.Log.Debug("_DEBUG", "Mounted: " + isMounted);
            if (!isMounted)
            {
                Android.Util.Log.Debug("_DEBUG", "ERROR: No external storage found! " + isMounted);
                return false;
            }

            return true;
        }


        /*
		 * Get the path to the external storage
		 */
        public string GetExternalStoragePath()
        {
            // make sure External Storage exists
            if (IsExternalStorageAvailable())
            {
                // get the path to the External Storage
                string path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic).AbsolutePath;
                return path;
            }

            return null;
        }

        /*
         * This gets a list of the files that are at the path passed to it
         * folderPath is the path to the folder
         * Return a list of the files that are in that folder
         */
        public string[] GetFileList(string folderPath)
        {
    //        List<string> fileList = new List<string>();

       //     string[] fileList = new string[Directory.GetFiles(folderPath).Length];
            string[] fileList = Directory.GetFiles(folderPath);

            return fileList;
        }

    }
}