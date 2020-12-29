using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOPingEventArgs : SocketIOBaseArgs
    {
        public SocketIOPingEventArgs() : base(SocketIOEventTypeEnum.Ping) { }
    }
}
