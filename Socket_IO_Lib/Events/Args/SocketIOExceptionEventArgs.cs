using Socket_IO_Lib.Helpers.Enums;

namespace Socket_IO_Lib.Events.Args
{
    public class SocketIOExceptionEventArgs : SocketIOBaseArgs
    {
        public string ExceptionMessage { get; private set; }
        public SocketIOExceptionEventArgs(string exceptionMessage) : base(SocketIOEventTypeEnum.Exception)
            => ExceptionMessage = exceptionMessage;
    }
}
