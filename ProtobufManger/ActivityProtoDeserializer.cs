using adbNoob.ProtobufClasses;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.ProtobufManger
{
    public class ActivityProtoDeserializer
    {
        public static IEnumerable<ActivityProto> DeserializeActivityProtoFromFile(string targetBinaryFilePath)
        {
           using (var targetBinaryFile = File.OpenRead(targetBinaryFilePath))
            {
                var activityProto = new ActivityProto();
                while(activityProto != null)
                {
                    activityProto = Serializer.DeserializeWithLengthPrefix<ActivityProto>(targetBinaryFile, PrefixStyle.Base128);
                    yield return activityProto;
                }
            }
        }
    }
}
