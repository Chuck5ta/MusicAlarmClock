using System;

namespace MusicAlarmClock
{
    public interface AudioInterface
    {        
        void PlayAudioFile(string fileName);
        void StopAudioFile();
    }
}
