using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOReconnectingEventArgs : SocketIOBaseArgs
    {
        public int Attempt { get; private set; }
        public SocketIOReconnectingEventArgs(int attempt) : base(SocketIOEventTypeEnum.Reconnecting)
            => Attempt = attempt;
    }
}
