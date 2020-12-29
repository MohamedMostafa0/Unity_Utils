using System;
using SocketIOClient;
using Socket_IO_Lib.Events;
using Socket_IO_Lib.Events.Args;
using Socket_IO_Lib.Helpers.Delegates;

namespace Socket_IO_Lib.Managers
{
    public static class SocketIOEventManager
    {
        private static event SocketIOEvent _socketIOEventHandler;
        public static event SocketIOEvent SocketIOEventHandler
        {
            add => _socketIOEventHandler += value;
            remove => _socketIOEventHandler -= value;
        }
        public static void FireException(string exceptionMessage)
        {
            SocketIOBaseArgs a = new SocketIOExceptionEventArgs(exceptionMessage);
            FireEvent(a);
        }
        public static void FireError(string errorMessage)
        {
            SocketIOBaseArgs a = new SocketIOErrorEventArgs(errorMessage);
            FireEvent(a);
        }
        public static void FireConnecting()
        {
            SocketIOBaseArgs a = new SocketIOConnectingEventArgs();
            FireEvent(a);
        }
        public static void FireConnected()
        {
            SocketIOBaseArgs a = new SocketIOConnectedEventArgs();
            FireEvent(a);
        }
        public static void FireDisconnected(string reason)
        {
            SocketIOBaseArgs a = new SocketIODisconnectedEventArgs(reason);
            FireEvent(a);
        }
        public static void FireReconnecting(int attempt)
        {
            SocketIOBaseArgs a = new SocketIOReconnectingEventArgs(attempt);
            FireEvent(a);
        }
        public static void FireReconnectingFailed(string failingMessage)
        {
            SocketIOBaseArgs a = new SocketIOReconnectingFailedEventArgs(failingMessage);
            FireEvent(a);
        }
        public static void FireRecievedMessage(string method, SocketIOResponse response)
        {
            SocketIOBaseArgs a = new SocketIORecievedMessageEventArgs(method, response);
            FireEvent(a);
        }
        public static void FireSentMessage(string method , SocketIOResponse response)
        {
            SocketIOBaseArgs a = new SocketIOSentMessageEventArgs(method , response);
            FireEvent(a);
        }
        public static void FirePing()
        {
            SocketIOBaseArgs a = new SocketIOPingEventArgs();
            FireEvent(a);
        }
        public static void FirePong(TimeSpan time)
        {
            SocketIOBaseArgs a = new SocketIOPongEventArgs(time);
            FireEvent(a);
        }
        private static void FireEvent(SocketIOBaseArgs args)
        {
            _socketIOEventHandler?.Invoke(args);
        }
    }
}
