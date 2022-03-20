using adbNoob;
using adbNoob.DatabaseManger;
using adbNoob.Generators;
using adbNoob.helpers;
using adbNoob.loggers;
using adbNoob.Parser;
using adbNoob.ProtobufClasses;
using adbNoob.ProtobufManger;
using System.Reactive.Linq;
//Dictionary<string, bool> deviceDictionary = new Dictionary<string, bool>();
//new Timer((object _) =>
//{
//    DeviceParser x = new();
//    var devicesId = x.GetConnectedDevices().ToList();
//    var parser = new ActivityParser();
//    var inserter = new Inserter();
//    foreach (var deviceId in devicesId)
//    {
//        if (!deviceDictionary.ContainsKey(deviceId))
//        {
//            deviceDictionary[deviceId] = true;
//            var generator = new CMDGenerator();
//            var activitiesLogProcess = generator.GetActivitiesLogProcess(deviceId);
//            activitiesLogProcess.Start();
//            var outpu = activitiesLogProcess.StandardOutput.BaseStream;
//            var observablActivities = (StreamObservable.ReadLines(outpu)) /*.Publish<string>()*/;
//            observablActivities.Subscribe(async activityLog =>
//            {
//                parser.ParseActivationLog(activityLog);
//                var activityName = parser.ActivityName;
//                var timeStamp = parser.TimeStamp;
//                var activity = new ActivityProto
//                {
//                    ActivityName = activityName,
//                    TimeStamp = timeStamp,
//                    DeviceId = deviceId,
//                };
//                ActivityProtoSerializer.SerializeActivityProtoIntoFile(activity, @"C:\Users\abdel\xsx.bin");
//                var activityDb = new Activity
//                {
//                    ActivityName = activityName,
//                    TimeStamp = timeStamp,
//                    DeviceId = deviceId,

//                };
//                await inserter.Insert(activityDb);
//                Console.WriteLine(activity.ActivityName + " " + activity.DeviceId + " " + timeStamp);
//            }, x => Console.WriteLine($"error {x}"), () => { Console.WriteLine("Device " + deviceId + " Disconnected " + DateTime.Now); deviceDictionary.Remove(deviceId); });
//        }
//    }
//}, null, 0, 1000);

//Console.ReadLine();
//Dictionary<string, bool> deviceDictionary = new Dictionary<string, bool>();
//new Timer((object _) =>
//{
//    DeviceParser deviceParser = new();
//    var devicesId = deviceParser.GetConnectedDevices().ToList();
//    var parser = new ActivityParser();
//    var inserter = new Inserter();
//    foreach (var deviceId in devicesId)
//    {
//        if (!deviceDictionary.ContainsKey(deviceId))
//        {
//            var generator = new CMDGenerator();
//            var activitiesLogProcess = generator.GetActivitiesLogProcess(deviceId);
//            activitiesLogProcess.Start();
//            deviceDictionary[deviceId] = true;
//            var observablActivities = StreamObservable.ReadLines(activitiesLogProcess.StandardOutput) /*.Publish<string>()*/;
//            observablActivities.Subscribe(_ => { });
//            observablActivities.Subscribe(_ => { });

//            //DatabaseLogger.DatabaseActivityLogger(ref observablActivities, deviceId, deviceDictionary);
//            //ProtoBufFileLogger.ProtoBufFileActivityLogger(ref observablActivities, deviceId, deviceDictionary);
//        }
//    }
//}, null, 0, 1000);
ActivityContext db = new ActivityContext();
var y = db.Activities.Select(x => x.ActivityId).ToList();
var x = ActivityProtoDeserializer.DeserializeActivityProtoFromFile(@"C:\Users\abdel\xsx.bin").ToList();
Console.ReadLine();
