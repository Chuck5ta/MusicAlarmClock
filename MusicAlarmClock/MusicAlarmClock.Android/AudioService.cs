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

		public void PlayAudioFile(string fileName)
		{
			Java.IO.File sdCard = Android.OS.Environment.ExternalStorageDirectory;

			Android.Util.Log.Debug("_DEBUG sdCard", sdCard.Name);



			// I need to make this look at the Music folder!!!!!
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMusic).AbsolutePath;
			Android.Util.Log.Debug("_DEBUG", path);
			//	var path = Environment.ExternalStorageDirectory.AbsolutePath;
			var file = path + "/" + fileName;
			Android.Util.Log.Debug("_DEBUG", file);


			Java.IO.File dir = new Java.IO.File(path + "/Hello");
			Android.Util.Log.Debug("_DEBUG dir", dir.ToString());
			if (!dir.Mkdirs())
				Android.Util.Log.Debug("_DEBUG", "FAILED TO CREATE");
			else
				Android.Util.Log.Debug("_DEBUG", "FOLDER CREATED");

			bool isReadonly = Environment.MediaMountedReadOnly.Equals(Environment.ExternalStorageState);
			Android.Util.Log.Debug("_DEBUG", "Read Only: " + isReadonly);

			bool isMounted = Environment.MediaMounted.Equals(Environment.ExternalStorageState);
			Android.Util.Log.Debug("_DEBUG", "Mounted: " + isMounted);

			//	Java.IO.File[] dirs = global::Android.App.Application.Context.GetExternalFilesDirs(Environment.DirectoryMusic);

			//	foreach (var item in dirs)
			//		Android.Util.Log.Debug("_DEBUG", item.AbsolutePath);


			StreamReader sr = new StreamReader(file);
			player = new MediaPlayer();
			player.SetDataSource(new StreamMediaDataSource(sr.BaseStream));
			player.Prepare();
			player.Start();



	//		player = new MediaPlayer();
		//	var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);

	//		var fd = global::Android.App.Application.Context.Assets.OpenNonAssetFd(file);
			
			//	var fod = global::Android.App.


			//		var _path = Context.GetExternalFilesDir(Environment.DirectoryMusic);


		/*	player.Prepared += (s, e) =>
			{
				player.Start();
			};
			player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
			player.Prepare(); */
		}

		public void StopAudioFile()
        {
			player.Stop();
		}

	}
}