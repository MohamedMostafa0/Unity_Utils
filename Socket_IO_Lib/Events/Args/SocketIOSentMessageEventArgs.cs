using Socket_IO_Lib.Helpers.Enums;
using SocketIOClient;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOSentMessageEventArgs : SocketIOBaseArgs
    {
        public string Method { get; private set; }
        public SocketIOResponse Response { get; private set; }
        public SocketIOSentMessageEventArgs(string method , SocketIOResponse response) : base(SocketIOEventTypeEnum.SentMessage)
        {
            Method = method;
            Response = response;
        }
    }
}
