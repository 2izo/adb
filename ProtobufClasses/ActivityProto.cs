using ProtoBuf;

namespace adbNoob.ProtobufClasses
{
    [ProtoContract]
    public class ActivityProto
    {
        [ProtoMember(1)]
        public string? ActivityName { get; set; }
        [ProtoMember(2)]
        public string? DeviceId { get; set; }
        [ProtoMember(3)]
        public ulong TimeStamp { get; set; }  
    }
}
