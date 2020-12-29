using System;
using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events
{
    public abstract class SocketIOBaseArgs : EventArgs
    {
        public SocketIOEventTypeEnum SocketIOEventType { get; private set; }
        public SocketIOBaseArgs(SocketIOEventTypeEnum socketIOEventType) =>
            SocketIOEventType = socketIOEventType;
    }
}
