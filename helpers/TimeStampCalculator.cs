using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.helpers
{
    public class TimeStampCalculator
    {
        public static ulong GetTimeStamp(string day, string time)
        {
            DateTime CurrentDate = DateTime.ParseExact(day + " " + time, "MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            var baseDate = new DateTime(1970, 01, 01);
            return (ulong)(CurrentDate.Subtract(baseDate).TotalSeconds);
        }
    }
}
