using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIODisconnectedEventArgs : SocketIOBaseArgs
    {
        public string Reason { get; private set; }
        public SocketIODisconnectedEventArgs(string reason) : base(SocketIOEventTypeEnum.Disconnected)
          => Reason = reason;
    }
}
