using adbNoob.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.Parser
{
    public class ActivityParser
    {
        public string ActivityName { get; set; }
        public ulong TimeStamp { get; set; }
        public Tuple<string, ulong> ParseActivationLog(string log)
        {
            string[] logData = log.Split(" ");
            logData = logData.Where(x=>!String.IsNullOrEmpty(x)).ToArray();
            string activity = logData[6];
            int activityNameStartIndex = activity.IndexOf(",", 0) + 1;
            int activityNameEndIndex = activity.IndexOf(",", activityNameStartIndex +1);
            ActivityName = activity.Substring(activityNameStartIndex, activityNameEndIndex - activityNameStartIndex);
            string day = logData[0];
            string time = logData[1];
            TimeStamp = TimeStampCalculator.GetTimeStamp(day, time);
            return Tuple.Create(ActivityName, TimeStamp);
        }
    }
}
