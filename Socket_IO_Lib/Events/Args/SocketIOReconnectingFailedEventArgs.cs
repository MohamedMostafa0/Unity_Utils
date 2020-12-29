using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOReconnectingFailedEventArgs : SocketIOBaseArgs
    {
        public string FailingMessage { get; private set; }
        public SocketIOReconnectingFailedEventArgs(string failingMessage) : base(SocketIOEventTypeEnum.ReconnectingFailed)
            => FailingMessage = failingMessage;
    }
}
