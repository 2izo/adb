using adbNoob.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.Parser
{
    public class DeviceParser
    {
        public string DeviceId { get; set; }
        private string GetDeviceId(string deviceLine)
        {
            string[] deviceData = deviceLine.Split(" ");
            if (deviceData.Length == 1)
            {
                deviceData = deviceLine.Split("\t");
                DeviceId = deviceData[0];
                return DeviceId;
            }
            return null;
        }
        public  IEnumerable<string> GetConnectedDevices()
        {
            var generator = new CMDGenerator();
            var processDevices = generator.GetDevicesProcess();
            processDevices.Start();
            var output = processDevices.StandardOutput.ReadLine();
            while(!string.IsNullOrEmpty(output))
            {
                var deviceId = GetDeviceId(output);
                if(deviceId != null)
                {
                    yield return GetDeviceId(output);
                }
                output = processDevices.StandardOutput.ReadLine();
            }
        }
    }
}
