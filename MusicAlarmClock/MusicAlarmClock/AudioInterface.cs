using System;
using System.Collections.Generic;

namespace MusicAlarmClock
{
    public interface AudioInterface
    {
        bool PlayAudioFile(string fileName);

        void StopAudioFile();
    }
}
