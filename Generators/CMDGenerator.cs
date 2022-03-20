using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reactive.Linq;

namespace adbNoob.Generators
{
    public class CMDGenerator
    {
        private Process GenerateCommandResultsProcess(string command)
        {
            var process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = command;  
           /*"/c adb logcat -b events | findstr am";*/
            process.StartInfo = startInfo;
            // Read the standard error of net.exe and write it on to console.
            return process;
        }

        public Process GetDevicesProcess()
        {
            return GenerateCommandResultsProcess("/c adb devices");
        }

        public Process GetActivitiesLogProcess(string deviceId)
        {
           return GenerateCommandResultsProcess("/c adb -s " + deviceId + " logcat -b events | findstr  am_on_resume_called");
        }
    }
}
