using System;
using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOPongEventArgs : SocketIOBaseArgs
    {
        public TimeSpan Time { get; private set; }
        public SocketIOPongEventArgs(TimeSpan time) : base(SocketIOEventTypeEnum.Pong)
            => Time = time;
    }
}
