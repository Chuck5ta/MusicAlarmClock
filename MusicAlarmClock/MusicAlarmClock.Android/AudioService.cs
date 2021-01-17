//using System;
using Xamarin.Forms;
using MusicAlarmClock.Droid;
using Android.Media;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using System.IO;

[assembly: Dependency(typeof(AudioService))]
namespace MusicAlarmClock.Droid
{
    class AudioService: AudioInterface
	{
		private MediaPlayer player;

		public AudioService()
		{
		}

		public bool PlayAudioFile(string fileName)
		{
			// I need to make this look at the Music folder!!!!!
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic).AbsolutePath;

			//	var path = Environment.ExternalStorageDirectory.AbsolutePath;
			var file = path + "/" + fileName;
		    //	Android.Util.Log.Debug("_DEBUG", file);

			bool isReadonly = Environment.MediaMountedReadOnly.Equals(Environment.ExternalStorageState);
			Android.Util.Log.Debug("_DEBUG", "Read Only: " + isReadonly);

			//	Java.IO.File[] dirs = global::Android.App.Application.Context.GetExternalFilesDirs(Environment.DirectoryMusic);

			//	foreach (var item in dirs)
			//		Android.Util.Log.Debug("_DEBUG", item.AbsolutePath);

			StreamReader sr = new StreamReader(file);
			player = new MediaPlayer();
			player.SetDataSource(new StreamMediaDataSource(sr.BaseStream));
			player.Prepare();
			player.Start();

			return true; // successfully played music file

		}

		public void StopAudioFile()
        {
			player.Stop();
		}

	}
}