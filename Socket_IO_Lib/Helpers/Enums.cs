namespace Socket_IO_Lib.Helpers.Enums
{
    public enum SocketIOEventTypeEnum : byte
    {
        Exception, Error, Connecting, Connected, Disconnected, Reconnecting, ReconnectingFailed, ReceivedMessage, SentMessage, Ping, Pong
    }
}
