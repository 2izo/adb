using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string? DeviceId { get; set; }
        public string? ActivityName { get; set; }
        public ulong TimeStamp { get; set; }
    }
}
