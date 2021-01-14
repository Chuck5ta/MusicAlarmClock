using System;

namespace MusicAlarmClock
{
    public interface AudioInterface
    {
        bool PlayAudioFile(string fileName);
        void StopAudioFile();
    }
}
