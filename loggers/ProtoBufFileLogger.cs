using adbNoob.Parser;
using adbNoob.ProtobufClasses;
using adbNoob.ProtobufManger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.loggers
{
    public class ProtoBufFileLogger
    {
        public static IDisposable ProtoBufFileActivityLogger(ref IObservable<string> protoBuffObservable, string deviceId, Dictionary<string,bool> deviceDictionary)
        {
           ActivityParser parser = new();
           return protoBuffObservable.Subscribe(activityLog =>
            {
                parser.ParseActivationLog(activityLog);
                var activityName = parser.ActivityName;
                var timeStamp = parser.TimeStamp;
                var activityProto = new ActivityProto
                {
                    ActivityName = activityName,
                    TimeStamp = timeStamp,
                    DeviceId = deviceId,
                };
                ActivityProtoSerializer.SerializeActivityProtoIntoFile(activityProto, @"C:\Users\abdel\KKK.bin");
            }, x => Console.WriteLine($"Error {x}"), () => { Console.WriteLine("Device " + deviceId + " Disconnected " + DateTime.Now); deviceDictionary.Remove(deviceId); });
        }
    }
}
