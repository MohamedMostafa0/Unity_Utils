using SocketIOClient;
using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIORecievedMessageEventArgs : SocketIOBaseArgs
    {
        public string Method { get; private set; }
        public SocketIOResponse Response { get; private set; }
        public SocketIORecievedMessageEventArgs(string method, SocketIOResponse response) : base(SocketIOEventTypeEnum.ReceivedMessage)
        {
            Method = method;
            Response = response;
        }
    }
}
