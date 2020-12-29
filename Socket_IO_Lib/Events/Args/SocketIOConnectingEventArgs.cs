using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOConnectingEventArgs : SocketIOBaseArgs
    {
        public SocketIOConnectingEventArgs() : base(SocketIOEventTypeEnum.Connecting) { }
    }
}
