using adbNoob.ProtobufClasses;
using ProtoBuf;

namespace adbNoob.ProtobufManger
{
    public class ActivityProtoSerializer
    {
        public static void SerializeActivityProtoIntoFile(ActivityProto activityProto, string targetBinaryFilePath)
        {
            try
            {
                using (var targetBinaryFile = File.Open(targetBinaryFilePath, FileMode.Append))
                {
                    Serializer.SerializeWithLengthPrefix(targetBinaryFile, activityProto, PrefixStyle.Base128);
                
                }
            }
            catch (Exception ex) { }
        }
    }
}
