//using System;
using Xamarin.Forms;
using MusicAlarmClock.Droid;
using Android.Media;
using Android.Content.Res;
using Android.OS;


[assembly: Dependency(typeof(AudioService))]
namespace MusicAlarmClock.Droid
{
    class AudioService: AudioInterface
	{
		private MediaPlayer player;

		public AudioService()
		{
		}

		public void PlayAudioFile(string fileName)
		{
			// I need to make this look at the Music folder!!!!!
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic).AbsolutePath;
		//	var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
			var file = path + "/" + fileName;

			player = new MediaPlayer();
		//	var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
			var fd = global::Android.App.Application.Context.Assets.OpenNonAssetFd(file);

		//	var fod = global::Android.App.

			player.Prepared += (s, e) =>
			{
				player.Start();
			};
			player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
			player.Prepare();
		}

		public void StopAudioFile()
        {
			player.Stop();
		}

	}
}