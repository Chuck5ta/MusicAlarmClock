//using System;
using Xamarin.Forms;
using MusicAlarmClock.Droid;
using Android.Media;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

[assembly: Dependency(typeof(AudioService))]
namespace MusicAlarmClock.Droid
{
    class AudioService: AudioInterface
	{
		public MediaPlayer player;

		public AudioService()
		{
		}

		public int PlayAudioFile(string fileName)
		{
			// I need to make this look at the Music folder!!!!!
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic).AbsolutePath;

			//	var path = Environment.ExternalStorageDirectory.AbsolutePath;
			var file = path + "/" + fileName;
		    //	Android.Util.Log.Debug("_DEBUG", file);

			bool isReadonly = Environment.MediaMountedReadOnly.Equals(Environment.ExternalStorageState);
	//		Android.Util.Log.Debug("_DEBUG", "Read Only: " + isReadonly);

			StreamReader sr = new StreamReader(file);
			player = new MediaPlayer();
			player.SetDataSource(new StreamMediaDataSource(sr.BaseStream));
			player.Prepare();
			player.Start();

			return player.Duration;  // return duration of song

		}

		public void StopAudioFile()
        {
			player.Stop();
		}

	}
}