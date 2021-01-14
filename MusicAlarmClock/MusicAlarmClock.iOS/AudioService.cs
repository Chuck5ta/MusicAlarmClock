using System;
using Xamarin.Forms;
using MusicAlarmClock;
using MusicAlarmClock.iOS;
using System.IO;
using Foundation;
using AVFoundation;

[assembly: Dependency(typeof(AudioService))]
namespace MusicAlarmClock.iOS
{
    class AudioService: AudioInterface
	{
		AVAudioPlayer _player;

		public AudioService()
		{
		}

		public bool PlayAudioFile(string fileName)
		{
			string sFilePath = NSBundle.MainBundle.PathForResource
			(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
			var url = NSUrl.FromString(sFilePath);
			_player = AVAudioPlayer.FromUrl(url);
	//		_player.Delegate = this;
			_player.Volume = 100f;
			_player.PrepareToPlay();
			_player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
				_player = null;
			};
			_player.Play();

			return true;
		}

		public void StopAudioFile()
		{
			_player.Stop();
		}

		public void Dispose()
		{

		}
	}
}