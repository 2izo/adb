using adbNoob.DatabaseManger;
using adbNoob.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.loggers
{
    public class DatabaseLogger
    {
        public static IDisposable DatabaseActivityLogger (ref IObservable<string> databaseObservable, string deviceId, Dictionary<string, bool> deviceDictionary)
        {
            Inserter inserter = new();
            ActivityParser parser = new();
            return databaseObservable.Subscribe(async activityLog =>
            {
                parser.ParseActivationLog(activityLog);
                var activityName = parser.ActivityName;
                var timeStamp = parser.TimeStamp;
                var activityDb = new Activity
                {
                    ActivityName = activityName,
                    TimeStamp = timeStamp,
                    DeviceId = deviceId,
                };
                await inserter.Insert(activityDb);
                Console.WriteLine(activityDb.ActivityName + " " + activityDb.DeviceId + " " + timeStamp);
            }, x => Console.WriteLine($"Error {x}"), () => { Console.WriteLine("Device " + deviceId + " Disconnected " + DateTime.Now); deviceDictionary.Remove(deviceId); });
        }
    }
}
