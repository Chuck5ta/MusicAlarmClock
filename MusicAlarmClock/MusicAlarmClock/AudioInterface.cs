using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAlarmClock
{
    public interface AudioInterface
    {
        int PlayAudioFile(string fileName);

        void StopAudioFile();

    }
}
