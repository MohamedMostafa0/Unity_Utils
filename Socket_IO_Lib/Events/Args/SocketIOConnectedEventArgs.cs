using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOConnectedEventArgs : SocketIOBaseArgs
    {
        public SocketIOConnectedEventArgs() : base(SocketIOEventTypeEnum.Connected) { }
    }
}
