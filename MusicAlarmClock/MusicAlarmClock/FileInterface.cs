using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAlarmClock
{
    public interface FileInterface
    {
        string GetExternalStoragePath();

        string[] GetFileList(string folderPath);

    }
}
